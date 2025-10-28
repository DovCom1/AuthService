CREATE TABLE "user" (
    "id" SERIAL PRIMARY KEY,
    "email" VARCHAR NOT NULL UNIQUE,
    "hash_password" TEXT NOT NULL
);