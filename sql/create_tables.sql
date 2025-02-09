drop table if exists users;
drop table if exists clubs;
drop table if exists leagues;
drop table if exists matches;

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

-- INSERT INTO Users (login, password, role, name)
-- VALUES 
--     ('user1', 'password1', 'admin', 'Alice'),
--     ('user2', 'password2', 'user', 'Bob'),
--     ('user3', 'password3', 'user', 'Charlie');

-- INSERT INTO Clubs (name, id_league)
-- VALUES 
--     ('Club A', 1),
--     ('Club B', 1),
--     ('Club C', 2);

-- INSERT INTO Leagues (name, id_user)
-- VALUES 
--     ('League 1', 1),
--     ('League 2', 2),
--     ('League 3', 3);

-- INSERT INTO Matches (goal_home_club, goal_guest_club, id_league, id_home_club, id_guest_club)
-- VALUES 
--     (2, 1, 1, 1, 2),
--     (3, 3, 1, 2, 3),
--     (0, 2, 2, 1, 3);
-- select * from users
DO $$ 
BEGIN 
    FOR i IN 1..100 LOOP 
        INSERT INTO Users (login, password, role, name) 
        VALUES ( 
            'user' || i, 
            'password' || i, 
            CASE WHEN i % 2 = 0 THEN 'Admin' ELSE 'Referee' END, 
            'User  ' || i 
        ); 
    END LOOP; 
END $$;

DO $$ 
BEGIN 
    FOR i IN 1..10 LOOP  -- Assuming you want 10 leagues
        INSERT INTO Leagues (name, id_user) 
        VALUES ( 
            'League ' || i, 
            (i % 100) + 1  -- Assign a user from 1 to 100
        ); 
    END LOOP; 
END $$;

DO $$ 
BEGIN 
    FOR i IN 1..100 LOOP 
        INSERT INTO Clubs (name, id_league) 
        VALUES ( 
            'Club ' || i, 
            (i % 10) + 1  -- Assign to leagues 1 to 10
        ); 
    END LOOP; 
END $$;

DO $$ 
BEGIN 
    FOR i IN 1..100 LOOP 
        INSERT INTO Matches (goal_home_club, goal_guest_club, id_league, id_home_club, id_guest_club) 
        VALUES ( 
            (random() * 5)::int,  -- Random goals between 0 and 5
            (random() * 5)::int, 
            (i % 10) + 1,  -- Random league from 1 to 10
            (random() * 99)::int + 1,  -- Random club from 1 to 100
            (random() * 99)::int + 1
        ); 
    END LOOP; 
END $$;