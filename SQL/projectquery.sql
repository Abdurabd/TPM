
drop database TrainerPoolManagement

CREATE database TrainerPoolManagement
use TrainerPoolManagement

create table skillset(skill_id bigint primary key not null,
skill_name varchar(20))
insert into skillset values(5,'C')
SELECT * FROM skillset
create table trainer (trainerId bigint primary key not null identity(1,1),
first_name varchar(50), 
last_name varchar(50),
gender varchar(10),
contact_no bigint,
age bigint,
userid varchar(20) not null,
password_user varchar(20) not null,
userType varchar(10),
emailId varchar(20),
)

create table sme (smeId bigint primary key not null identity(1,1),
first_name varchar(50), 
last_name varchar(50),
gender varchar(10),
contact_no bigint,
age bigint,
userid varchar(20) not null,
password_user varchar(20) not null,
userType varchar(10),
emailId varchar(20),
)

create table requestor (requestorId bigint primary key not null identity(1,1),
first_name varchar(50), 
last_name varchar(50),
gender varchar(10),
contact_no bigint,
age bigint,
userid varchar(20) not null,
password_user varchar(20) not null,
userType varchar(10),
emailId varchar(20),
)

create table trainer_skills(skills_id bigint primary key not null identity(1,1),
trainer_Id  bigint foreign key references trainer(trainerId),
skillid bigint foreign key references skillset(skill_id))

create table sme_skills(sme_skills_id bigint primary key not null identity(1,1),
sme_Id  bigint foreign key references sme(smeId),
skillid bigint foreign key references skillset(skill_id))

create table request(requestId bigint primary key not null identity(1,1),
requestor_Id bigint foreign key references requestor (requestorId),  
skillsubject bigint foreign key references skillset(skill_id),
startdate date,
enddate date,
venue varchar(20),request_status varchar(10))

create table trainerNomination( trainerNominationId bigint primary key not null identity(1,1), 
requestId  bigint foreign key references request(requestId),
trainer_Id  bigint foreign key references trainer(trainerId))

create table smeNomination( smeNominationId bigint primary key not null identity(1,1), 
requestId  bigint foreign key references request(requestId),
sme_Id  bigint foreign key references sme(smeId))

create table adminToTrainer (adminTrainerReqId bigint primary key not null identity(1,1), 
requestId  bigint foreign key references request(requestId),
trainer_Id  bigint foreign key references trainer(trainerId))

create table adminToSme (adminSmeReqId bigint primary key not null identity(1,1), 
requestId  bigint foreign key references request(requestId),
sme_Id  bigint foreign key references sme(smeId))

create table allocated(allocatedId bigint primary key not null identity(1,1), 
requestId  bigint foreign key references request(requestId),
trainer_Id  bigint foreign key references trainer(trainerId) null,
sme_Id  bigint foreign key references sme(smeId) null)

create table trainerAvailability(trainerAvailabilityId  bigint primary key not null identity(1,1), 
trainer_Id  bigint foreign key references trainer(trainerId),
requestId  bigint foreign key references request(requestId)/*,
startDate date foreign key references  request(startdate),
enddate  date foreign key references  request(enddate)*/)

create table smeAvailability(smeAvailabilityId  bigint primary key not null identity(1,1), 
sme_Id  bigint foreign key references sme(smeId),
requestId  bigint foreign key references request(requestId)/*,
startDate date foreign key references  request(startdate),
enddate  date foreign key references  request(enddate)*/)

create table adminDetails(adminId  bigint primary key not null,
username varchar(20) not null,
password_admin varchar(20) not null)

insert into skillset values(1,'Java')
insert into skillset values(4,'Python')
select * from skillset

SELECT * FROM request
select t.trainerId,t.first_name,t.last_name,s.skill_name
from trainer t join trainer_skills a
on t.trainerId=a.trainer_Id  
join skillset s 
on a.skills_id=s.skill_id 


select * from trainer
select * from  trainer_skills where trainer_id=1


select * from skillset s join trainer_skills t on s.skill_id=t.skills_id where t.trainer_id=2

insert into TRAINER values(
'KOHLI','kv','male',9490249261,22,'799448','Pads23','sme','kana@gmail.com'),
('DHONI','kv','male',9490249261,21,'799501','Pa23','hr','kana@gmail.com')
insert into sme_skills
values (
6,2)
select * from sme
select * from trainer t join trainer_skills ts on t.trainerId=ts.trainer_id join skillset s on ts.skillid=s.skill_id where skill_name='Java'
SELECT * FROM trainer_skills
select * from sme
select * from sme_skills
select * from sme  st join sme_skills ts on st.smeId=ts.sme_Id join skillset s on ts.skillid=s.skill_id where skill_name='Dotnet'
select * from skillset s join sme_skills ss on s.skill_id=ss.skillid where ss.sme_Id=2

select * from request
insert into request values(2,2,'2019/02/22','2019/02/28','Hyd','ON')

insert into requestor values(
'gfdy','kv','male',9490249261,22,'799448','Pads23','sme','kana@gmail.com'),
('anjhaf','kv','male',9490249261,21,'799501','Pa23','hr','kana@gmail.com')

select * from request r join  skillset s on r.skillsubject=s.skill_id join requestor rq on rq.requestorId=r.requestor_Id 

INSERT INTO trainer_skills values(8,2)

select * from skillset

insert into skillset values(4,'Python')
-->changing size of email nd password for trainer/sme/requestor
alter table  trainer alter column emailid varchar(50)
alter table  sme alter column emailid varchar(50)
alter table requestor alter column emailId varchar(50)
select * from sme
select * from requestor

create proc sp_Traineruseridcheck
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from trainer
	where [userid]=@userid and [password_user]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end


select * from trainer
exec sp_Traineruseridcheck 'deepthi123','123456'

--create proc sp_RegUser
--@first_name varchar(50) ,
--@last_name varchar(50),
--@gender varchar(10),
--@contact_no bigint,
--@age bigint,
--@userid varchar(20) not null,
--@password_user varchar(20) not null,
--@userType varchar(10),
--@emailId varchar(20)
--as
--begin
--       declare @count int
--          declare @count_user int 
--       declare @returncode int
--       select @count=count([us_emp_id]),@count_user=count([us_username]) from [dbo].[user]
--       where[us_emp_id] =@us_emp_id or [us_username]=@us_username

--       if @count>0 or @count_user>0
--       begin
--              set @returncode=-1
--       end
--       else
--    begin
--       set @returncode=1
--       insert into [dbo].[user] values
--              (
--              @us_first_name,
--              @us_last_name,
--              @us_designation,
--              @us_emp_id,
--              @us_seat_no,
--              @us_pc_no,
--              @us_ip_address,
--              @us_contact_no,
--              @us_username,
--              @us_password)
--   end

-->login check for sme/trainer/requestor
create proc sp_usercheck
@userid nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from trainer
	where [userid]=@userid
	if(@count>0)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end

create proc sp_requestorusercheck
@userid nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from requestor
	where [userid]=@userid
	if(@count>0)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end

create proc sp_smeusercheck
@userid nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from sme
	where [userid]=@userid
	if(@count>0)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end
select * from sme
select * from trainer
select * from trainer_skills
insert into skillset
values(4,'python')

select * from trainer
select * from adminDetails

insert into adminDetails
values(1,'Rashik','riya94')
select * from adminDetails

create proc sp_admincheckuserid
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(username) from adminDetails
	where [username]=@userid and [password_admin]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end
select * from trainer_skills
select * from sme
select * from sme_skills
select * from requestor
select * from 
create proc sp_Traineruseridcheck
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from trainer
	where [userid]=@userid and [password_user]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end
create proc sp_admincheckuserid
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(username) from adminDetails
	where [username]=@userid and [password_admin]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end
select * from trainerAvailability
create proc sp_requestorcheckuserid
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from requestor
	where [userid]=@userid and [password_user]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end

create proc sp_smecheckuserid
@userid nvarchar(50),
@password nvarchar(50)
as Begin
	Declare @count int
	select @count=count(userid) from sme
	where [userid]=@userid and [password_user]=@password
	if(@count=1)
	Begin
	select 1 as Returncode
	End
	Else
	Begin
	select -1 as Returncode
	end
end


select * from adminDetails
exec sp_admincheckuserid 'Rashik','riya94'

select * from requestor
select * from sme
select * from sme_skills
select * from trainer_skills
select * from trainerAvailability
select * from trainerNomination
select * from request
select * from smeAvailability
select * from skillset
insert into trainerAvailability
values(6,'2019/08/10','2019/08/14','Available')
select * from trainer t join trainer_skills ts on t.trainerId=ts.trainer_id join skillset s on ts.skillid=s.skill_id where skill_name=@skill_name

select * from trainer t  join trainerAvailability ts on t.trainerId=ts.trainer_id 
 join trainer_skills tss on t.trainerId=tss.trainer_Id  join skillset s on tss.skillid=s.skill_id 
where ts.startDate<='2019/08/10' and ts.enddate>='2019/08/14' and ts.availability_status='Available' and s.skill_name='MainFrame'

select * from skillset s join trainer_skills ts on s.skill_id=ts.skillid join trainer t on ts.trainer_Id=t.trainerId join trainerAvailability ta on t.trainerId=ta.trainer_Id
where s.skill_name='Java' and ta.startDate<='2019/08/10' and ta.enddate>='2019/08/14' and ta.availability_status='Available'

insert into trainer values(
'gfdy','kv','male',9490249261,22,'799448','Pads23','sme','kana@gmail.com'),
('anjhaf','kv','male',9490249261,21,'799501','Pa23','hr','kana@gmail.com')

insert into trainer_skills values(6,2)
truncate table adminApprovedSme

select * from smeAvailability where trainer_id = 2
select * from trainer
select * from request
select * from sme
select * from adminApprovedSme
insert into adminApprovedSme values(8,3)
select * from adminApprovedTrainer
select * from adminApprovedSme
select * from request
select * from sme
select * from request r join  skillset s on r.skillsubject=s.skill_id join requestor rq on rq.requestorId=r.requestor_Id where r.requestId=10010

select r.requestId,at.trainer_Id,saa.sme_Id from  request r left join adminApprovedTrainer at on r.requestId=at.requestId left  join adminApprovedSme saa on r.requestId=saa.requestId where r.requestId=10011


delete from adminApprovedSme where requestId=10011
select * from trainer_skills where trainer_Id=2
--update trainer_skills
--set skillid=
alter table requestor add [description] varchar(1000) default 'null'
select * from requestor
alter table trainer add [description] varchar(1000) default 'null'
select * from trainer
alter table sme add [description] varchar(1000) default 'null'
select * from sme
delete from trainer_skills where trainer_Id=2 and skillid=3
Select skill_name,startdate,enddate,venue from request join skillset on skillsubject=skill_id where requestor_Id=7 order by  requestId desc
select * from requestor

create proc sp_random
@randomno varchar(50),
@username varchar(20)
as 
Begin
update trainer set password_user=@randomno where userid=@username
end

create proc sp_randomsme
@randomno varchar(50),
@username varchar(20)
as 
Begin
update sme set password_user=@randomno where userid=@username
end

create proc sp_randomrequestor
@randomno varchar(50),
@username varchar(20)
as 
Begin
update requestor set password_user=@randomno where userid=@username
end

exec sp_random '12345','HemanthLucky'


create proc sp_updatepassword
@otp varchar(50),
@newpassword varchar(50),
@username varchar(20)
as Begin
update trainer set password_user=@newpassword where userid=@username and password_user=@otp
end

create proc sp_updatepasswordsme
@otp varchar(50),
@newpassword varchar(50),
@username varchar(20)
as Begin
update sme set password_user=@newpassword where userid=@username and password_user=@otp
end

create proc sp_updatepasswordrequestor
@otp varchar(50),
@newpassword varchar(50),
@username varchar(20)
as Begin
update requestor set password_user=@newpassword where userid=@username and password_user=@otp
end
select * from adminApprovedTrainer
exec sp_updatepassword '12345','123456','HemanthLucky'
select * from trainer
select * from adminToTrainer
select * from request
select * from adminToTrainer
select * from skillset

select * from request r join adminToTrainer at on r.requestId=at.requestId join skillset ss on ss.skill_id=r.skillsubject  where at.trainer_Id=2 and r.request_status='ON' 
and r.requestId not in (select requestId from trainerNomination)
select * from request
select * from adminToSme
select * from sme
delete trainerNomination 
where requestId=10025
select * from request r join 
select * from trainerNomination
select * from smeNomination
select * from smeNomination
-->trainer/sme for not coming it is in trainerdao/sme dao
Select requestId,skill_name,startdate,enddate,venue from request r join skillset s on r.skillsubject=s.skill_id where request_status='ON' and r.requestId not in (select requestId from trainerNomination)
Select requestId,skill_name,startdate,enddate,venue from request r join skillset s on r.skillsubject=s.skill_id where request_status='ON' and r.requestId not in (select requestId from smeNomination)
select * from request r join adminToSme at on r.requestId = at.requestId join skillset ss on ss.skill_id = r.skillsubject  and r.request_status = 'ON' 
and r.requestId not in (select requestId from smeNomination where sme_Id=9)


delete smeNomination 
where requestId=10033

select * from sme
select * from sme_skills

select * from request r join adminApprovedTrainer at on r.requestId=at.requestId join skillset s on s.skill_id=r.skillsubject where at.trainer_Id=2 order by r.requestId desc

insert into trainerAvailability values (4,GETDATE(),GETDATE(),'Available')

select * from trainerAvailability
select *from requestor
select * from smeNomination
select * from smeAvailability
delete from smeNomination where sme_Id=8
insert into smeAvailability
values(4,'2019/08/17','2019/09/23','Available')
select count(smeNominationId) from smeNomination where requestId=2 and sme_Id=2
insert into smeAvailability 
values(8,'2019/09/18','2019/10/19','Available')
select * from adminToTrainer

select * from smeNomination
truncate table trainerNomination