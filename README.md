## TelephoneDirectory
TelephoneDirectory is an innovative application designed to efficiently handle and organize telephone number directories. Employing a microservice architecture, this application comprises three distinct components: directory, report, and consumer. Each component plays a crucial role in the overall functionality of the system.

The directory microservice serves as the backbone for managing telephone directory data. It provides a comprehensive REST API that facilitates seamless operations such as creating, retrieving, updating, and deleting entries within the directory. By utilizing this microservice, users can easily maintain and manipulate their telephone number records.

The report microservice, on the other hand, specializes in generating insightful reports based on the directory data. With the support of its dedicated REST API, users can effortlessly request various types of reports. This microservice harnesses the power of the directory information, enabling users to extract valuable insights and make informed decisions.

Lastly, the consumer component operates as a background worker, actively listening for incoming messages on a message queue. Its primary responsibility revolves around processing requests for reports. By leveraging the report microservice, the consumer diligently generates the requested reports, ensuring prompt and accurate delivery to the users.

In summary, TelephoneDirectory introduces an efficient microservice-based approach to effectively manage telephone number directories. The directory microservice handles data management, the report microservice provides comprehensive reporting capabilities, and the consumer component orchestrates the generation and delivery of reports. Together, these components seamlessly collaborate to offer an enhanced user experience and streamline directory management processes.

#### General structure
- Message Broker -> Rabbitmq
- Databases -> MongoDB
- Open Doc -> Swagger

#### Installation
Thanks to the `docker-compose.yml` file, both the tools used and the databases will run properly. To start the application, navigate to the root directory of the project and run the following command:
```
docker-compose -f docker-compose.yml up --build -d
```

You can then access the following URLs:

-   Directory API Swagger UI: [http://localhost:8081/swagger](http://localhost:8081/swagger)
-   Report API Swagger UI: [http://localhost:8082/swagger](http://localhost:8082/swagger)
-   Report Consumer CAP UI: [http://localhost:8083/cap](http://localhost:8083/cap)
-   RabbitMQ GUI: [http://localhost:15672](http://localhost:15672/)

#### Credentials

- RabbitMQ GUI: 
```
- username: 'guest', 
- password: 'guest'
```
- MongoDB: 
```
- username: 'usrAdmin', 
- password: 'xE!4IsEt#i4IzA8riAg'
```
