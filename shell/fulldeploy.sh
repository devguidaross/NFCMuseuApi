echo ">>> PUBLISH WEBAPI <<<"
echo ""

## Excluíndo arquivos atualmente na pasta destino da publicação
rm -r "../MuseuApi/publish"

# Publicar projetos como release
dotnet publish "../MuseuApi/MuseuApi.csproj" -c Release -o "./publish" -f netcoreapp2.1

echo ">>> DOTNET BUILD - CONCLUIDO <<<"
echo ""

echo ">>> DOCKER BUILD <<<"
cd ../MuseuApi
docker rmi --force guidaross/nfcunescmuseu:1.0
docker build -t guidaross/nfcunescmuseu:1.0 .
echo ""

echo ">>> DOCKER PUSH  <<<"
docker push guidaross/nfcunescmuseu:1.0
echo ""

cd ../shell/DockerCompose

echo ">>> DOCKER COMPOSE <<<"
docker-compose -f 02-App.yml -p museunfc down

docker-compose -f 02-App.yml -p museunfc up --no-start
docker-compose -f 01-Infra.yml -p museunfc up --no-start

docker-compose -f 02-App.yml -p museunfc start
docker-compose -f 01-Infra.yml -p museunfc start
echo ""

echo ">>> FINISH <<<"