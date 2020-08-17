@echo off
echo Generating certificates . . .
dotnet dev-certs https -ep ./PUSGS_Project.Api.Aviations/certificate.pfx -p Pa55word
dotnet dev-certs https -ep ./PUSGS_Project.Api.RentACars/certificate.pfx -p Pa55word
dotnet dev-certs https -ep ./PUSGS_Project.Api.Users/certificate.pfx -p Pa55word
dotnet dev-certs https -ep ./PUSGS_Project.ApiGateway/certificate.pfx -p Pa55word
echo Building Aviation Api . . .
docker image build -f "PUSGS_Project.Api.Aviations\Dockerfile" --quiet --force-rm=true --tag aviation-api .
echo Building Rent-a-car Api . . .
docker image build -f "PUSGS_Project.Api.RentACars\Dockerfile" --quiet --force-rm=true --tag rentacar-api .
echo Building User Api . . .
docker image build -f "PUSGS_Project.Api.Users\Dockerfile" --quiet --force-rm=true --tag users-api .
echo Building Api-gateway Api . . .
docker image build -f "PUSGS_Project.ApiGateway\Dockerfile" --quiet --force-rm=true --tag gateway-api .
echo Building Kubernetes Deployments and Services . . .
kubectl apply -f "k8s"
echo Removing intermediate images . . .
docker image prune --force
echo removed intermediate images!
echo.
echo Setup Complete!