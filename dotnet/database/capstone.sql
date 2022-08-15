USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE pets (
	pet_id int IDENTITY NOT NULL,
	name varchar(50) NOT NULL,
	age varchar(50) NOT NULL,
	size varchar(50) NOT NULL,
	breed varchar(50) NOT NULL,
	temperament varchar(200) NOT NULL,
	energy varchar(50) NOT NULL, 
	bio varchar(200) NOT NULL,
	image_url varchar(200) NOT NULL,
	CONSTRAINT PK_pet PRIMARY KEY (pet_id)
)
CREATE TABLE user_pet
(
user_id INT,
pet_id INT,
CONSTRAINT FK_user_up FOREIGN KEY (user_id) REFERENCES users(user_id),
CONSTRAINT FK_pet_up FOREIGN KEY (pet_id) REFERENCES pets(pet_id),
);
CREATE TABLE playdates (
	playdate_id int IDENTITY NOT NULL,
	creator_id int NOT NULL,
	play_park_address varchar(200) NOT NULL,
	play_park_name varchar(200) NOT NULL,
	play_park_location_notes varchar(1000) NOT NULL,
	playdate_time_date datetime NOT NULL,
	CONSTRAINT PK_playdate PRIMARY KEY (playdate_id),
	CONSTRAINT FK_creator_playdate FOREIGN KEY (creator_id) REFERENCES users(user_id)
)
CREATE TABLE user_pet_playdate
(
user_id INT NOT NULL,
pet_id INT NOT NULL,
playdate_id INT NOT NULL,
playdate_status VARCHAR(20) NOT NULL,
CONSTRAINT FK_user_upp FOREIGN KEY (user_id) REFERENCES users(user_id),
CONSTRAINT FK_pet_upp FOREIGN KEY (pet_id) REFERENCES pets(pet_id),
CONSTRAINT FK_playdate_upp FOREIGN KEY (playdate_id) REFERENCES playdates(playdate_id)
);
--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


INSERT INTO pets (name,age,size,breed,temperament,energy,bio) VALUES ('Buddy','Puppy','Small','Beagle','Aggressive','Medium','Stupid Little Dog :)')
INSERT INTO pets (name,age,size,breed,temperament,energy,bio) VALUES ('TuffDude','Adult','Mini','Beagle','Aggressive','Medium','Stupid Tiny Dog :)')

INSERT INTO user_pet(user_id,pet_id) VALUES (1,1)
INSERT INTO user_pet(user_id,pet_id) VALUES (1,2)
INSERT INTO user_pet(user_id,pet_id) VALUES (2,1)

INSERT INTO playdates(creator_id, play_park_address, play_park_name, play_park_location_notes, playdate_time_date) VALUES (1, '1046 County Road 1175, Ashland, OH 44805', 'Peppy Paws Pooch Park, LLC', 'A 5-acre and 1-acre fenced park open daily from dawn until dusk. Day passes or annual passes are available for purchase.', '2012-02-21T18:10:00')
INSERT INTO playdates(creator_id, play_park_address, play_park_name, play_park_location_notes, playdate_time_date)
	VALUES (2, '1505 Merwin Ave., Cleveland, OH 44113', 'Downtown Cleveland Dog Park', 'An on-leash agility course with six stations including an A-frame ramp and teeter-totter.', '2012-02-21T18:10:00')
INSERT INTO playdates(creator_id, play_park_address, play_park_name, play_park_location_notes, playdate_time_date)
	VALUES (2, '6647 Hopkins Rd., Mentor, OH 44060', 'City of Mentor Dog Park', 'An off-leash dog park with separate areas for large and small dogs as well as a doggie water fountain, park benches, and a safe, fenced-in entry/exit area', '2012-02-21T18:10:00')
UPDATE playdates SET playdate_time_date = '2012-02-21T18:10:00' WHERE playdate_id = 1
UPDATE playdates SET playdate_time_date = '2012-02-21T18:10:00' WHERE playdate_id = 3
INSERT INTO user_pet_playdate(user_id, pet_id, playdate_id, playdate_status)
	VALUES(1, 1, 1, 'Accepted')
INSERT INTO user_pet_playdate(user_id, pet_id, playdate_id, playdate_status)
	VALUES(2, 1, 2, 'Accepted')
	INSERT INTO user_pet_playdate(user_id, pet_id, playdate_id, playdate_status)
	VALUES(2, 2, 3, 'Accepted')
GO
select * from users
select * from pets
select * from user_pet
select * from playdates
select * from user_pet_playdate

select * from playdates Where playdate_id = 1

SELECT playdates.playdate_id, playdates.creator_id, playdates.play_park_address, play_park_name, playdates.play_park_location_notes, playdates.playdate_time_date FROM playdates WHERE creator_id= 1
;
