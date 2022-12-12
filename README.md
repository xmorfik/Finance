docker build -t webapi -f Finance.WebApi/Dockerfile . <br />
docker run -d --name webapi -p 5000:80 webapi <br />
docker build -t webui -f Finance.Ui/Dockerfile . <br />
docker run -d --name webui -p 5001:80 webui <br />

