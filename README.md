# FLSChallenge-DotNet

## Database

MSSQL 2019 is used through Docker. In order to generate your database please change the ConnectionString at ```appsettings.json``` and run ```dotnet ef database update``` under Infrastructuer layer.

## Running the app 

Once the application is opened it will seed some date like Cart, Item and ItemDiscountRule. Their ids will be

```
Cart1 - 4e5fc42c-4a3a-46bf-bdc6-93e67e1e9abb
Cart2 - 9370d3af-7c05-46a8-940e-250f21cbbb76
Cart3 - ee1605d8-9bcd-4054-811e-27d5985bee64

Item1 (Vase) - e5715f5d-5c72-4564-9bbd-31bdedb93bed
Item1 (Big mug) - af3987bb-8a3b-4e53-b61b-858883655c8e
Item1 (Napkins pack) - 40ebcec1-9268-4e34-8d10-a47bd9d10fa4

ItemDiscountRule1 = e0b358c4-b225-42b0-a272-1846b94ee4db - the rule for Big mugs (2 for 1.5)
ItemDiscountRule1 = c0a7d3c6-c259-4987-b9dd-f480a7f1a342 - the rule for Napkins pack (3 for 0.9)
```

Please not that there is no CartItems seeded. it will require to add some manually through API (Swagger available).

p.s - Tests can be found under FSLChallengeDotNet.Tests
