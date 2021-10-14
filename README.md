# Eagle
Build Docker Image
  docker build -f Dockerfile . -t eagle

Run Docker Image
  docker run -d --name eagle-redis -p 6379:6379 redis
