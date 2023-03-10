USE Sem3Project
/*							Select all table					*/
select * from tblDepartment
select * from tblCategory
select * from tblFactory
select * from tblWareHouse
select * from tblBanner
select * from tblAccountAdmin
select * from tblAccountUser
select * from tblProduct
select * from tblOrder
select * from tblOrderDetail

/*							Insert into							*/
/* tblFactory  */
insert into tblFactory(Code,Name,Status,CreatedDate,ModifiedDate) values
('F100','Factory 001',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('F200','Factory 002',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('F300','Factory 003',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('F400','Factory 004',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblWarehouse */
insert into tblWareHouse(Code,Name,FactoryId,Status,CreatedDate,ModifiedDate) values
('WH01','Ware House 01',1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('WH02','Ware House 02',2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('WH03','Ware House 03',3,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),		
('WH04','Ware House 04',4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblDepartment */
insert into tblDepartment(Code,Name,Status,CreatedDate,ModifiedDate) values
('DP_DP_01','Despartch Department 01',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('DP_DP_02','Despartch Department 02',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('DP_OD_01','Order Processing Department 01',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('DP_OD_02','Order Processing Department 02',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('DP_PD_01','Production Department 01',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('DP_PD_02','Production Department 02',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblCategory */
insert into tblCategory(Code,Name,Description,Status,CreatedDate,ModifiedDate) values
('C101','Lightning','The part at the front of the car, helping to illuminate when traveling at night.',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('C102','Engine System','The part that helps the vehicle move by converting fuel into kinetic energy.',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('C103','Wheels & Tires','Made from neoprene, which is the part in contact with the ground, reducing friction and reducing shock.',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('C104','Electric System','Electrical and electronic systems interfere with nearly all systems on a vehicle, from simple old systems such as starting, power supply, and ignition to new systems that are researched and applied. such as brake, steering, suspension.',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblProduct */
insert into tblProduct(Code,Name,Description,Price,SalePrice,Quantity,Images,CategoryId,WareHouseID,Status,CreatedDate,ModifiedDate) values 
('Pro_01_2301','Highlights Mazda 3 2020','Color White, Insurrance 12 months, Made in China',310,307,2500,'highlight_Mazda_3.png',1,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_02_2301','Highlights BMW 750i 2021','Color White, Insurrance 16 months, Made in Califonia',990,0,2000,'highlight_BMW_750i.png',1,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_03_2301','Highlights Mercedes 2020','Color Custom, Insurrance 1 year, Made in China',1100,1080,2000,'highlight_mercedes_2020.jpg',1,3,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_04_2301','Lexus RS350 Engine','Insurrance 12 months, Made in China',11000,0,1300,'lexus_350_engine.jpg',2,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_05_2301','Huyndai i10 Engine','Insurrance 6 months, Made in China',490,485,1300,'huyndai_i10_engine.png',2,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_06_2301','KIA Morning Engine 2021','Insurrance 10000 km, Made in Taiwan',550,0,1300,'kia_morning_engine.jpg',2,3,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_07_2301','Subaru Forester Engine 2018','Insurrance 8000 km, Made in ThaiLand',7990,7989,1300,'subaru_forester_engine.png',2,4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_08_2301','Vinfast Lux Turbo SA2.0 Wheels','Quantity 1 wheels,Insurrance 5000km, Made in Vietnam',50,0,1300,'vinfast_lux_sa2.0_wheel.png',3,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_09_2301','Kia Cerato 2019 Tires','Quantity 1 pair of tire & wheel,Insurrance 9000 km, Made in China',80,70,1300,'kia_cerato_tire.png',3,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_10_2301','Mitsubishi XPander WheelsTires','Full set of tires & wheels, Insurrance 12000 km, Made in Korean',309,0,1300,'mitsubishi_XPander_wheels&tire.jpg',3,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_11_2301','Mercedes Wheels','Quantity 1 wheel, Insurrance 12 months, Made in China',400,390,1300,'mercedes_wheels.jpg',3,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_12_2301','Huyndai Santa Fe CWD 2021','1 pair of tire & wheel, Insurrance 5000km, Made in ThaiLand',900,0,1300,'Huyndai_santafe_CWD_wheel&tire.jpg',3,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_13_2301','Huyndai Tucson New 2022','Fullset tire & wheel, Insurrance 12000km , Made in Vietnam',550,450,1300,'Huyndai_tucson_2022_wheel.jpg',3,4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_14_2301','Kia K3 new version 2022 Tire','Quantity 1 tire, Insurrance 3 months, Made in Thailand',670,0,1300,'Kia_k3_wheel.png',3,4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_15_2301','ECU Mazda CX5 2019','15WHP, Insurrance 12 months, Made in China',550,549,1300,'Ecu_mazda_cx5.jpg',4,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_16_2301','Lithiumion LFP Batery for Electric car','Insurrance 3 months, Made in Vietnam',250,0,1300,'Lithium-ion LFP Batery.png',4,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_17_2301','Atlas MF3 Batery','12V-100AH,Insurrance 1 month, Made in China',600,550,1300,'Atlas_MF3.jpg',4,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_18_2301','DongNai N100 Batery','12V-100AH, Insurrance 1 month, Made in Vietnam',50,0,1300,'Dongnai_N100_Batery.jpg',4,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_19_2301','Kia Sedona Generator','Color black, Insurrance 12 months, Made in Japan',360,358,1300,'kia_sedona_genetor.jpg',4,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Pro_20_2301','Howo 371 Starter','Insurrance 1 year, Made in China',700,0,1300,'howo_starter.jpg',4,3,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblAccountAdmin */
insert into tblAccountAdmin(Code,Name,Gender,Birthday,Address,Email,Phone,Status,Password,Role,DepartmentId,CreatedDate,ModifiedDate) values
('Admin_001','Admin AA01',0,'2000-09-30','Phu Tho','admin01@gmail.com','0397589165',1,'12345678',1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Admin_002','Admin AA02',1,'1996-04-25','Hoa Binh','admin02@gmail.com','0375649342',2,'12345678',2,2,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblAccountUser */
insert into tblAccountUser(Code,Name,Gender,Birthday,Address,Email,Phone,Password,Role,Status,CreatedDate,ModifiedDate) values
('User_A01','Hoang Thi Xuyen',0,'1975-12-20','Hung Yen','baxuyenhy@gmail.com','0998272474','123456789',1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('User_A02','Nguyen Van Hao',1,'1982-07-16','Hai Duong','nguyenvanhao@gmail.com','0846724054','987654321',2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('User_B01','Le Van Dao',1,'1979-01-29','Bac Giang','daolevan@gmail.com','0342901197','29011979',3,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('User_C01','Tran Thi Tuyet',0,'1986-08-13','Lao Cai','tuyetlaocai86@gmail.com','0985147259','123456789',4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/* tblBanner */
insert into tblBanner(Code,Name,Description,Image,Status,CreatedDate,ModifiedDate) values
('Banner02','Banner_02','null','banner02.png',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('Banner03','Banner_03','null','banner03.png',1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
/*tblOrder*/
INSERT  INTO tblOrder( CODE, NAME,Address,Email,Phone,Note,AccountUserId,TotalQuantity,TotalAmount,STATUS,Payment,CreatedDate,ModifiedDate)
  VALUES 
  ('45678', 'Hoang Thi Xuyen','Hung Yen','baxuyenhy@gmail.com','0998272474','',1,1,18420,0,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
 ('40608', 'Nguyen Van Hao','Hai Duong','nguyenvanhao@gmail.com','0846724054','',2,2,49500,1,0,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
 ('45888', 'Hoang Thi Xuyen','Hung Yen','baxuyenhy@gmail.com','0998272474','',1,2,49500,2,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
 ('45888', 'Le Van Dao','Bac Giang','daolevan@gmail.com','0342901197','',3,1,18420,3,0,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('45989', 'Hoang Thi Xuyen','Hung Yen','baxuyenhy@gmail.com','0998272474','',1,1,18420,4,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('41981', 'Hoang Thi Xuyen','Hung Yen','baxuyenhy@gmail.com','0998272474','',1,1,18420,5,0,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
('43401', 'Hoang Thi Xuyen','Hung Yen','baxuyenhy@gmail.com','0998272474','',1,1,18420,6,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP);

INSERT  INTO tblOrderDetail( ProductId, Quantity,Price,Status,OrderId,CreatedDate,ModifiedDate)
  VALUES 
  (1,60,307,1,1,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,2,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (2,50,990,1,2,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,3,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (2,50,990,1,3,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,4,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,5,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,6,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP),
  (1,60,307,1,7,CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)