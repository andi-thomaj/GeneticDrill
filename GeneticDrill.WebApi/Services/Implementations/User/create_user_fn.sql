create or replace function create_user(
    first_name varchar, 
    last_name varchar, 
    email varchar,
    frontend_theme varchar,
    "password" varchar default null,
    middle_name varchar default null,
    google_picture_url varchar default null) 
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
    insert into users(
        first_name,
        last_name, 
        email,
        frontend_theme,
        "password",
        middle_name,
        google_picture_url
    )
    values(
        first_name,
        last_name, 
        email,
        frontend_theme,
        "password",
        middle_name,
        google_picture_url
    )
    returning 
        "id", 
        first_name, 
        middle_name, 
        last_name, 
        email, 
        google_picture_url, 
        frontend_theme, 
        users.is_blocked, 
        users.is_deleted, 
        users.created_at;
$$ language sql;