### Commands to Remember

- `git init` - Initialize a local Git repository
- `git add .` - Stage all changes in the working directory
- `git commit -m "message"` - Commit staged changes to the local repository
- `git push origin master` - Push changes from the local repository to the remote repository

### Docker Postgresql

- `docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres` - Run a Postgres container
- `docker exec -it some-postgres psql -U postgres` - Connect to the Postgres container
- `docker pull postgres` - Pull the latest Postgres image
- `docker run --name eda-db -p 5432:5432 -e POSTGRES_PASSWORD=demo -d postgres` - Run a Postgres container with a specific password
- `postgress login` - username: postgres, password: demo

### Docker Commands

- `docker ps` - List all running containers
- `docker ps -a` - List all containers
- `docker stop container_id` - Stop a running container
- `docker start container_id` - Start a stopped container
- `docker rm container_id` - Remove a container
- `docker images` - List all images

### Docker Compose

- `docker-compose up` - Create and start containers

### RabbitMQ

- `docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management` - Run a RabbitMQ container
- `docker pull rabbitmq` - Pull the latest RabbitMQ image
