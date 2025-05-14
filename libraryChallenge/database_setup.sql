--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: authors; Type: TABLE; Schema: library_db; Owner: postgres
--

CREATE TABLE library_db.authors (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    dateofbirth timestamp without time zone NOT NULL
);


ALTER TABLE library_db.authors OWNER TO postgres;

--
-- Name: authors_id_seq; Type: SEQUENCE; Schema: library_db; Owner: postgres
--

CREATE SEQUENCE library_db.authors_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE library_db.authors_id_seq OWNER TO postgres;

--
-- Name: authors_id_seq; Type: SEQUENCE OWNED BY; Schema: library_db; Owner: postgres
--

ALTER SEQUENCE library_db.authors_id_seq OWNED BY library_db.authors.id;


--
-- Name: books; Type: TABLE; Schema: library_db; Owner: postgres
--

CREATE TABLE library_db.books (
    id integer NOT NULL,
    title character varying(255) NOT NULL,
    publicationyear integer NOT NULL,
    authorid integer NOT NULL
);


ALTER TABLE library_db.books OWNER TO postgres;

--
-- Name: books_id_seq; Type: SEQUENCE; Schema: library_db; Owner: postgres
--

CREATE SEQUENCE library_db.books_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE library_db.books_id_seq OWNER TO postgres;

--
-- Name: books_id_seq; Type: SEQUENCE OWNED BY; Schema: library_db; Owner: postgres
--

ALTER SEQUENCE library_db.books_id_seq OWNED BY library_db.books.id;


--
-- Name: authors id; Type: DEFAULT; Schema: library_db; Owner: postgres
--

ALTER TABLE ONLY library_db.authors ALTER COLUMN id SET DEFAULT nextval('library_db.authors_id_seq'::regclass);


--
-- Name: books id; Type: DEFAULT; Schema: library_db; Owner: postgres
--

ALTER TABLE ONLY library_db.books ALTER COLUMN id SET DEFAULT nextval('library_db.books_id_seq'::regclass);


--
-- Name: authors authors_pkey; Type: CONSTRAINT; Schema: library_db; Owner: postgres
--

ALTER TABLE ONLY library_db.authors
    ADD CONSTRAINT authors_pkey PRIMARY KEY (id);


--
-- Name: books books_pkey; Type: CONSTRAINT; Schema: library_db; Owner: postgres
--

ALTER TABLE ONLY library_db.books
    ADD CONSTRAINT books_pkey PRIMARY KEY (id);


--
-- Name: books fk_author; Type: FK CONSTRAINT; Schema: library_db; Owner: postgres
--

ALTER TABLE ONLY library_db.books
    ADD CONSTRAINT fk_author FOREIGN KEY (authorid) REFERENCES library_db.authors(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

