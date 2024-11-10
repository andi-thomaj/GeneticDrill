create or replace function create_user(
    first_name varchar, 
    middle_name varchar, 
    last_name varchar, 
    email varchar, 
    google_picture_url varchar, 
    frontend_theme varchar) 
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
        middle_name,
        last_name, 
        email,
        google_picture_url,
        frontend_theme)
    values(
        first_name,
        middle_name,
        last_name, 
        email,
        google_picture_url,
        frontend_theme)
    returning 
        "id", 
        first_name, 
        middle_name, 
        last_name, 
        email, 
        google_picture_url, 
        frontend_theme, 
        is_blocked, 
        is_deleted, 
        created_at;
$$ language sql;
