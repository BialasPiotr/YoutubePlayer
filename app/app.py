from flask import Flask, request, jsonify
from flasgger import Swagger

app = Flask(__name__)
swagger = Swagger(app)

videos = {}

@app.route('/videos', methods=['POST'])
def create_video():
    """
    Create a new video
    ---
    tags:
      - videos
    parameters:
      - in: body
        name: body
        schema:
          type: object
          required:
            - videoId
          properties:
            videoId:
              type: string
              description: Unique identifier of the video
            title:
              type: string
              description: Title of the video
            description:
              type: string
              description: Description of the video
    responses:
      201:
        description: Video created
      400:
        description: Invalid input
    """
    data = request.json
    video_id = data.get('videoId')
    if not video_id:
        return jsonify(error="Missing videoId"), 400
    videos[video_id] = data
    return jsonify(success=True), 201

@app.route('/videos', methods=['GET'])
def list_videos():
    """
    List all videos
    ---
    tags:
      - videos
    responses:
      200:
        description: List of videos
    """
    return jsonify(videos=list(videos.values()))

@app.route('/videos/<videoId>', methods=['GET'])
def get_video(videoId):
    """
    Get a specific video by videoId
    ---
    tags:
      - videos
    parameters:
      - name: videoId
        in: path
        type: string
        required: true
        description: Unique identifier of the video
    responses:
      200:
        description: Video found
      404:
        description: Video not found
    """
    video = videos.get(videoId)
    if video is None:
        return jsonify(error="Video not found"), 404
    return jsonify(video=video)

@app.route('/videos/<videoId>', methods=['PUT'])
def update_video(videoId):
    """
    Update a specific video by videoId
    ---
    tags:
      - videos
    parameters:
      - name: videoId
        in: path
        type: string
        required: true
        description: Unique identifier of the video
      - in: body
        name: body
        schema:
          type: object
          properties:
            title:
              type: string
              description: Title of the video
            description:
              type: string
              description: Description of the video
    responses:
      200:
        description: Video updated
      404:
        description: Video not found
    """
    data = request.json
    if videoId in videos:
        videos[videoId] = data
        return jsonify(success=True)
    return jsonify(error="Video not found"), 404

@app.route('/videos/<videoId>', methods=['DELETE'])
def delete_video(videoId):
    """
    Delete a specific video by videoId
    ---
    tags:
      - videos
    parameters:
      - name: videoId
        in: path
        type: string
        required: true
        description: Unique identifier of the video
    responses:
      200:
        description: Video deleted
      404:
        description: Video not found
    """
    if videoId in videos:
        del videos[videoId]
        return jsonify(success=True)
    return jsonify(error="Video not found"), 404

if __name__ == '__main__':
    app.run(debug=True, port=5000)