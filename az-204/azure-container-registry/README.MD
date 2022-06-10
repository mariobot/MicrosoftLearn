## Create a container image and publish with Azure container registry

Login to azure
```bash
az login
```

Create a resource group
```bash
az group create --name az204-acr-rg --location centralus
```

Create the container registry 
```bash
az acr create --resource-group az204-acr-rg --name mboteroimage --sku Basic
```

Create a Dockerfile and and
```bash
FROM mcr.microsoft.com/hello-world
```

```bash
az acr build --image sample/hello-world:v1 --registry mboteroimage --file Dockerfile .
```

## Check Resources

Use the next command to show the repositories of the registry
```bash
az acr repository list --name mboteroimage --output table
```

Use the next command to show the tags from the repository
```bash
az acr repository show-tags --name mboteroimage --repository sample/hello-world --output table
```

## Execution of Image in (ARC)

The next command execute the image from the container registry
```bash
az acr run --registry mboteroimage --cmd '$Registry/sample/hello-world:v1' /dev/null
```

Delete the resource
```bash
az group delete --name az204-acr-rg
```

```bash
```