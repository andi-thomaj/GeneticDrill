create or replace function update_user(
    user_id uuid,
    new_first_name varchar,
    new_middle_name varchar,
    new_last_name varchar,
    new_frontend_theme varchar
) returns table(
    status varchar,
    id uuid,
    first_name varchar,
    middle_name varchar,
    last_name varchar,
    email varchar,
    google_picture_url varchar,
    frontend_theme varchar,
    is_blocked boolean,
    is_deleted boolean,
    created_at timestamp
) language sql as $$
    with updated as (
        update users
        set first_name = new_first_name,
            middle_name = new_middle_name,
            last_name = new_last_name,
            frontend_theme = new_frontend_theme
        where id = user_id
        returning id, first_name, middle_name, last_name, email, google_picture_url, frontend_theme, is_blocked, is_deleted, created_at
    )
select
    case when exists (select 1 from updated) then 'success' else 'not_found' end as status,
    id,
    first_name,
    middle_name,
    last_name,
    email,
    google_picture_url,
    frontend_theme,
    is_blocked,
    is_deleted,
    created_at
from updated;
$$;
