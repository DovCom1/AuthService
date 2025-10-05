CREATE TABLE "user" (
    "id" SERIAL PRIMARY KEY,
    "username" VARCHAR NOT NULL UNIQUE,
    "hash_password" TEXT NOT NULL
);