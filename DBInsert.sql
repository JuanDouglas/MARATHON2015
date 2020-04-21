USE MarathonSkills;
GO
INSERT INTO  _Role (RoleName) VALUES('Admin');
INSERT INTO  _Role (RoleName) VALUES('User');

INSERT INTO _User (Email,FirstName,LastName,_Password,RoleId) VALUES ('juandouglas2004@gmail.com','Juan','Douglas','Ana995076',1);
INSERT INTO _User (Email,FirstName,LastName,_Password,RoleId) VALUES ('thiagocabelin123@gmail.com','Thiago','Cabelin','ana7355608',1)

SELECT * FROM _User;