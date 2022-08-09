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
	CONSTRAINT PK_pet PRIMARY KEY (pet_id)
)
CREATE TABLE user_pet
(
user_id INT,
pet_id INT,
CONSTRAINT FK_user_up FOREIGN KEY (user_id) REFERENCES users(user_id),
CONSTRAINT FK_pet_up FOREIGN KEY (pet_id) REFERENCES pets(pet_id)
);



--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


INSERT INTO pets (name,age,size,breed,temperament,energy,bio) VALUES ('Buddy','Puppy','Small','Beagle','Aggressive','Medium','Stupid Little Dog :)')
INSERT INTO pets (name,age,size,breed,temperament,energy,bio) VALUES ('TuffDude','Adult','Mini','Beagle','Aggressive','Medium','Stupid Tiny Dog :)')

INSERT INTO user_pet(user_id,pet_id) VALUES (1,1)
INSERT INTO user_pet(user_id,pet_id) VALUES (1,2)
INSERT INTO user_pet(user_id,pet_id) VALUES (2,1)
GO
select * from users
select * from pets
select * from user_pet
