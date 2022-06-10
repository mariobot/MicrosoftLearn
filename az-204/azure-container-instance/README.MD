## Azure Container Instance

Login to azure
```bash
az login
```

Create the resource group
```bash
az group create --name az204-aci-rg --location centralus
```

Create a container
```bash
az container create --resource-group az204-aci-rg --name mycontainer --image mcr.microsoft.com/azuredocs/aci-helloworld --ports 80 --dns-name-label aci-example-mbotero --location centralus
```

Check the container status 
```bash
az container show --resource-group az204-aci-rg --name mycontainer --query "{FQDN:ipAddress.fqdn,ProvisioningState:provisioningState}" --out table
```

Whe you run the previous command will be show estatus of the container and the final route to test the app.
Copy the url and paste in your browser for my case is http://aci-example-mbotero.centralus.azurecontainer.io 

Delete the resource
```bash
az group delete --name az204-aci-rg --no-wait
```