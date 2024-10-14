-- drop table users;
-- drop table clubs;
-- drop table leagues;
-- drop table matches;
create table if not exists Users
(
	id serial primary key,
	login varchar(64) not null unique,
	password varchar(64) not null,
	role varchar(64) not null,
	name varchar(64) default 'hieu'
);

create table if not exists Clubs
(
	id serial not null primary key,
	name varchar(64) not null unique,
	id_league int default -1
);

create table if not exists Leagues
(
	id serial not null primary key,
	name varchar(64) not null unique,
	id_user int,
	
	foreign key (id_user) references Users(id) on delete cascade
);

create table if not exists Matches
(
	id serial not null primary key,
	goal_home_club int default -1,
	goal_guest_club int default -1,
	id_league int not null,
	id_home_club int not null,
	id_guest_club int not null,
	
	foreign key (id_league) references Leagues(id) on delete cascade,
	foreign key (id_home_club) references Clubs(id) on delete cascade,
	foreign key (id_guest_club) references Clubs(id) on delete cascade
);