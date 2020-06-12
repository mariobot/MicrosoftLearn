#FROM microsoft/aspnetcore:2.2
FROM microsoft/aspnetcore-build
COPY output /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT [ "dotnet", "ContosoPets.Ui.dll" ]

# BEFORE GENERATE THE RELEASE
#dotnet publish --configuration Release --output output

# LATER
# docker build . -t contoso/contosopetsui -f Dockerfile

# LIST IMAGES
# docker images

# create a container with the image
# docker create -p 3000:80 --name contosopetsui contoso/contosopetsui

# CHECK THE CONTAINER CREATIN
# docker ps -a

# TO START THE CONTAINER
# docker ps 
