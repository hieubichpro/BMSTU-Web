insert into users(login, password, role, name) values ('messi', '1', 'Referee', 'LM10');
insert into users(login, password, role, name) values ('ronaldo', '1', 'Referee', 'hieu');
select * from leagues
delete from users where id = 4
insert into clubs(name) values ('Chelsea'), ('Arsenal');
insert into leagues(name, id_user) values ('EPL', 1), ('La Liga', 2);
insert into leagues(name, id_user) values ('La Liga', 2);
insert into matches(id_home_club, id_guest_club, id_league) values (1, 2, 1), (2, 1,1)
insert into matches(id_home_club, id_guest_club, id_league) values (2, 1,1)
select * from users