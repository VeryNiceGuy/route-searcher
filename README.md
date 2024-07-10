# route-searcher
 
Request body examples:

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00",
  "filters": {
    "destinationDateTime": "03-08-2024 0:00:00"
  }
}

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00",
  "filters": {
  "destinationDateTime": "03-08-2024 0:00:00",
   "onlyCached": false
  }
}

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00",
  "filters": {
  "destinationDateTime": "03-08-2024 0:00:00",
   "onlyCached": true
  }
}

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00",
  "filters": {
   "destinationDateTime": "03-08-2024 0:00:00",
   "maxPrice": 200000
  }
}

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00",
  "filters": {
   "destinationDateTime": "03-08-2024 0:00:00",
   "maxPrice": 200000,
   "MinTimeLimit": "10-08-2024 0:00:00"
  }
}

{
  "origin": "London",
  "destination": "Moscow",
  "originDateTime": "01-08-2024 0:00:00"
}