# Eagle
# Build Docker Image
  docker build -f Dockerfile . -t eagle

# Run Docker Image
  docker run -d --name eagle-redis -p 6379:6379 redis

# Run RabbitMQ
  docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management

# Run Redis
  docker run --name redis -d redis
