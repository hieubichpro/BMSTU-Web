### Без балансировки:

```
ab -n 1000 -c 100 http://localhost/api/v1/clubs
```

```
This is ApacheBench, Version 2.3 <$Revision: 1913912 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 100 requests
Completed 200 requests
Completed 300 requests
Completed 400 requests
Completed 500 requests
Completed 600 requests
Completed 700 requests
Completed 800 requests
Completed 900 requests
Completed 1000 requests
Finished 1000 requests


Server Software:        nginx/1.26.2
Server Hostname:        localhost
Server Port:            80

Document Path:          /api/v1/clubs
Document Length:        77 bytes

Concurrency Level:      100
Time taken for tests:   2.271 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      221000 bytes
HTML transferred:       77000 bytes
Requests per second:    440.29 [#/sec] (mean)
Time per request:       227.125 [ms] (mean)
Time per request:       2.271 [ms] (mean, across all concurrent requests)
Transfer rate:          95.02 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.2      0       1
Processing:    14  222  67.9    218     457
Waiting:       11  222  68.0    218     457
Total:         14  222  67.9    218     457

Percentage of the requests served within a certain time (ms)
  50%    218
  66%    242
  75%    262
  80%    270
  90%    298
  95%    343
  98%    397
  99%    426
 100%    457 (longest request)

```

### С балансировкой:

```
 ab -n 1000 -c 100 http://localhost/api/v1/clubs
```

```
This is ApacheBench, Version 2.3 <$Revision: 1913912 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 100 requests
Completed 200 requests
Completed 300 requests
Completed 400 requests
Completed 500 requests
Completed 600 requests
Completed 700 requests
Completed 800 requests
Completed 900 requests
Completed 1000 requests
Finished 1000 requests

Server Software: nginx/1.26.2
Server Hostname: localhost
Server Port: 80

Document Path: /api/v1/clubs\
Document Length: 0 bytes

Concurrency Level: 100
Time taken for tests: 1.905 seconds
Complete requests: 1000
Failed requests: 0
Non-2xx responses: 1000
Total transferred: 123000 bytes
HTML transferred: 0 bytes
Requests per second: 524.81 [#/sec] (mean)
Time per request: 190.543 [ms] (mean)
Time per request: 1.905 [ms] (mean, across all concurrent requests)
Transfer rate: 63.04 [Kbytes/sec] received

Connection Times (ms)
min mean[+/-sd] median max
Connect: 0 0 0.2 0 2
Processing: 29 176 56.5 166 409
Waiting: 29 175 56.5 166 408
Total: 29 176 56.5 166 409

Percentage of the requests served within a certain time (ms)
50% 166
66% 186
75% 197
80% 209
90% 274
95% 298
98% 315
99% 335
100% 409 (longest request)

```
