param([string] $version)

Set-Location "../"

# build docker images according to docker-compose
docker-compose -f docker-compose.yml build

# rename images with following tag
docker tag nicmangroup-aos-api nicmangroup/aos-api:$version

# push to docker hub
docker push nicmangroup/aos-api:$version