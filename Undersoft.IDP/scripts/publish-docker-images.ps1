param([string] $version)

Set-Location "../"

# build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# rename images with following tag
docker tag nicmangroup-ais-admin nicmangroup/ais-admin:$version
docker tag nicmangroup-ais-sts-identity nicmangroup/ais-sts-identity:$version
docker tag nicmangroup-ais-admin-api nicmangroup/ais-admin-api:$version

# push to docker hub
docker push nicmangroup/ais-admin:$version
docker push nicmangroup/ais-admin-api:$version
docker push nicmangroup/ais-sts-identity:$version