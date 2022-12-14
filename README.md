docker build -t webapi -f Finance.WebApi/Dockerfile . <br />
docker run -d --name webapi -p 5000:80 webapi <br />
docker build -t webui -f Finance.Ui/Dockerfile . <br />
docker run -d --name webui -p 5001:80 webui <br />


![Screenshot (4)](https://user-images.githubusercontent.com/56976694/207603910-1dfeb754-c82d-4ee4-a2fa-590322c96fcf.png)
![Screenshot (1)](https://user-images.githubusercontent.com/56976694/207603917-286857d8-84dc-41cc-9d53-3b654c4890e5.png)
![Screenshot (2)](https://user-images.githubusercontent.com/56976694/207603919-17bea064-24c8-4599-a78b-ead36beddc70.png)
![Screenshot (3)](https://user-images.githubusercontent.com/56976694/207603921-3adeadde-5b16-4eb9-ae52-393de9da2d27.png)
