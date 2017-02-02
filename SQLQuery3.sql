go

SELECT Cold_WaterНабор.Sum AS Cold, Hot_WaterНабор.Sum AS Hot,Cold_WaterНабор.Data,Hot_WaterНабор.Data,Cold_WaterНабор.HomID,Hot_WaterНабор.HomID

FROM Cold_WaterНабор LEFT JOIN Hot_WaterНабор
ON Cold_WaterНабор.HomID=Hot_WaterНабор.HomID
WHERE Cold_WaterНабор.HomID=Hot_WaterНабор.HomID; 

go