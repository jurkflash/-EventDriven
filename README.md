# Event Driven (pub/sub pattern)

Order as publisher and Cart as the subscriber(consumer)
Order will take input from rest api post to queue, cart configured to consume from the queue

Steps to run
1) Navigate to root folder
2) build image [docker build -f order/Dockerfile -t order . ; docker build -f cart/Dockerfile -t cart . ;]
3) Run: [docker-compose up]
4) Browser open http://localhost:5088/Swagger/index.html
5) Do a post for Order
6) Back to terminal will see the messages of order send and card receive.


PubSub with event handler
- Order Project --> OrderController --> HttpPost for route "Complete"
Request will send notification and appear in console output