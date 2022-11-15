#### .NET Microservices

The original Tutorial video can find in https://www.youtube.com/watch?v=DgVjEo3OGBI&t=37253s

* Building two .NET Microservices using the REST API pattern
* Working with dedicated persistence layers for both services
* Deploying our services to Kubernetes cluster
* Employing the API Gateway pattern to route to our services
* Building Synchronous messaging between services (HTTP & gRPC)
* Building Asynchronous messaging between services using an Event Bus (RabbitMQ)

## Commands

To create the docker image
```docker build -t mariobot/platformservice . ```
```docker build -t mariobot/commandservice . ```

To publish the docker image
```docker publish mariobot/platformservice ```
```docker publish mariobot/commandservice ```

To list deployments
```kubectl get deployments```

To list pods
```kubectl get pods```

To list services
```kubectl get services```

To restart deployment
```kubectl rollout restart deployment commands-depl```

To deploy
```kubectl apply -f platforms-depl.yaml ```
