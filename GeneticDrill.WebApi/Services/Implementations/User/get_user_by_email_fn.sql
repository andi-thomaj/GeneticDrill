create or replace function get_user_by_email(email varchar) 
returns table(
    "id" uuid,
    first_name varchar,
    middle_name varchar,
    last_name varchar,
    email varchar,
    google_picture_url varchar,
    frontend_theme varchar,
    is_blocked boolean,
    is_deleted boolean,
    created_at timestamp
) as $$
select u.id
     , u.first_name
     , u.middle_name
     , u.last_name
     , u.email
     , u.google_picture_url
     , u.frontend_theme
     , u.is_blocked
     , u.is_deleted
     , u.created_at
from users as u
where u.email = email;
$$ language sql;