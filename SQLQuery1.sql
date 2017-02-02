
Go
SELECT  Cold.Sum,Cold.Data,Cold.ID,
Hot.Sum,
Sewage.Sum,
Electr.Sum
From Cold_WaterНабор Cold
FULL JOIN Hot_WaterНабор Hot
ON Cold.HomID=Hot.HomID
FULL JOIN SewageНабор Sewage
ON Sewage.HomID=Cold.HomID
FULL JOIN ElectricityНабор Electr
ON Cold.HomID=Electr.HomID

go