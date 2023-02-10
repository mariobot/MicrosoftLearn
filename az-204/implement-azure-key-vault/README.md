Execute the next commands to create an Azure Key Value

Set this variables
```bash
myKeyVault=az204vault-$RANDOM
myLocation=<myLocation>
```

Create a resource group
```bash
az group create --name az204-vault-rg --location $myLocation
```

Create instance of Key Value
```bash
az keyvault create --name $myKeyVault --resource-group az204-vault-rg --location $myLocation
```

Creating a secret and save in the secret var
```bash
az keyvault secret set --vault-name $myKeyVault --name "ExamplePassword" --value "hVFkk965BuUv"
```

Read the secret from the keyvault
```bash
az keyvault secret show --name "ExamplePassword" --vault-name $myKeyVault
```

Delete the resource group
```bash
az group delete --name az204-vault-rg --no-wait
```
