## To execute the scripts you can do the next steps.

### Login to azure
´´´ login az ´´´

### Set the azure account
´´´ az account set --subscription "Concierge Subscription" ´´´

### If have problems with the set account set by id
´´´ az account set --subscription {your subscription ID} ´´´

### Set the default resource group
´´´´az configure --defaults group=[sandbox resource group name] ´´´

### Deployment of bicep script
´´´ az deployment group create --template-file main.bicep ´´´