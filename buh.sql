--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 17.2

-- Started on 2024-12-12 00:16:01

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
-- TOC entry 221 (class 1259 OID 57380)
-- Name: brigades; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.brigades (
    brigade_name text NOT NULL,
    brigade_id integer NOT NULL
);


ALTER TABLE public.brigades OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 57441)
-- Name: brigades_brigade_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.brigades_brigade_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.brigades_brigade_id_seq OWNER TO postgres;

--
-- TOC entry 4873 (class 0 OID 0)
-- Dependencies: 222
-- Name: brigades_brigade_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.brigades_brigade_id_seq OWNED BY public.brigades.brigade_id;


--
-- TOC entry 217 (class 1259 OID 57358)
-- Name: car_repair; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.car_repair (
    car_id integer NOT NULL,
    failure_id integer NOT NULL,
    arrival_date date NOT NULL,
    leaving_date date,
    brigade_id integer NOT NULL
);


ALTER TABLE public.car_repair OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 57373)
-- Name: cars; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cars (
    car_body_number text NOT NULL,
    car_engine_number text NOT NULL,
    car_owner text NOT NULL,
    car_vin text NOT NULL,
    car_id integer NOT NULL
);


ALTER TABLE public.cars OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 57451)
-- Name: cars_car_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cars_car_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.cars_car_id_seq OWNER TO postgres;

--
-- TOC entry 4874 (class 0 OID 0)
-- Dependencies: 223
-- Name: cars_car_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cars_car_id_seq OWNED BY public.cars.car_id;


--
-- TOC entry 226 (class 1259 OID 57521)
-- Name: cars_in_work; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.cars_in_work AS
 SELECT car_id,
    failure_id,
    arrival_date,
    leaving_date,
    brigade_id
   FROM public.car_repair
  WHERE (leaving_date = NULL::date);


ALTER VIEW public.cars_in_work OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 57361)
-- Name: failures; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.failures (
    failure_name text NOT NULL,
    work_cost integer DEFAULT 0,
    failure_id integer NOT NULL
);


ALTER TABLE public.failures OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 57461)
-- Name: failures_failure_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.failures_failure_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.failures_failure_id_seq OWNER TO postgres;

--
-- TOC entry 4875 (class 0 OID 0)
-- Dependencies: 224
-- Name: failures_failure_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.failures_failure_id_seq OWNED BY public.failures.failure_id;


--
-- TOC entry 227 (class 1259 OID 57525)
-- Name: free_brigades; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.free_brigades AS
 SELECT brigades.brigade_id,
    brigades.brigade_name
   FROM (public.brigades
     LEFT JOIN public.car_repair ON ((brigades.brigade_id = car_repair.brigade_id)))
  WHERE (car_repair.brigade_id = NULL::integer);


ALTER VIEW public.free_brigades OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 57533)
-- Name: number_of_failures_by_cars; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.number_of_failures_by_cars AS
SELECT
    NULL::integer AS car_id,
    NULL::text AS car_vin,
    NULL::bigint AS "number of failures";


ALTER VIEW public.number_of_failures_by_cars OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 57353)
-- Name: personnel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personnel (
    workshop_id integer NOT NULL,
    "person_INN" numeric(12,0) NOT NULL,
    brigade_id integer NOT NULL
);


ALTER TABLE public.personnel OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 57368)
-- Name: spare_parts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.spare_parts (
    car_id integer NOT NULL,
    failure_id integer NOT NULL,
    part_name text NOT NULL,
    part_cost integer DEFAULT 0 NOT NULL,
    part_amount integer NOT NULL
);


ALTER TABLE public.spare_parts OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 57346)
-- Name: workshops; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.workshops (
    workshop_name text NOT NULL,
    workshop_id integer NOT NULL
);


ALTER TABLE public.workshops OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 57471)
-- Name: workshops_workshop_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.workshops_workshop_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.workshops_workshop_id_seq OWNER TO postgres;

--
-- TOC entry 4876 (class 0 OID 0)
-- Dependencies: 225
-- Name: workshops_workshop_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.workshops_workshop_id_seq OWNED BY public.workshops.workshop_id;


--
-- TOC entry 4678 (class 2604 OID 57442)
-- Name: brigades brigade_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.brigades ALTER COLUMN brigade_id SET DEFAULT nextval('public.brigades_brigade_id_seq'::regclass);


--
-- TOC entry 4677 (class 2604 OID 57452)
-- Name: cars car_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cars ALTER COLUMN car_id SET DEFAULT nextval('public.cars_car_id_seq'::regclass);


--
-- TOC entry 4675 (class 2604 OID 57462)
-- Name: failures failure_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.failures ALTER COLUMN failure_id SET DEFAULT nextval('public.failures_failure_id_seq'::regclass);


--
-- TOC entry 4673 (class 2604 OID 57472)
-- Name: workshops workshop_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workshops ALTER COLUMN workshop_id SET DEFAULT nextval('public.workshops_workshop_id_seq'::regclass);


--
-- TOC entry 4863 (class 0 OID 57380)
-- Dependencies: 221
-- Data for Name: brigades; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.brigades (brigade_name, brigade_id) FROM stdin;
\.


--
-- TOC entry 4859 (class 0 OID 57358)
-- Dependencies: 217
-- Data for Name: car_repair; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.car_repair (car_id, failure_id, arrival_date, leaving_date, brigade_id) FROM stdin;
\.


--
-- TOC entry 4862 (class 0 OID 57373)
-- Dependencies: 220
-- Data for Name: cars; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cars (car_body_number, car_engine_number, car_owner, car_vin, car_id) FROM stdin;
\.


--
-- TOC entry 4860 (class 0 OID 57361)
-- Dependencies: 218
-- Data for Name: failures; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.failures (failure_name, work_cost, failure_id) FROM stdin;
\.


--
-- TOC entry 4858 (class 0 OID 57353)
-- Dependencies: 216
-- Data for Name: personnel; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.personnel (workshop_id, "person_INN", brigade_id) FROM stdin;
\.


--
-- TOC entry 4861 (class 0 OID 57368)
-- Dependencies: 219
-- Data for Name: spare_parts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.spare_parts (car_id, failure_id, part_name, part_cost, part_amount) FROM stdin;
\.


--
-- TOC entry 4857 (class 0 OID 57346)
-- Dependencies: 215
-- Data for Name: workshops; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.workshops (workshop_name, workshop_id) FROM stdin;
bruh customs	1
\.


--
-- TOC entry 4877 (class 0 OID 0)
-- Dependencies: 222
-- Name: brigades_brigade_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.brigades_brigade_id_seq', 1, false);


--
-- TOC entry 4878 (class 0 OID 0)
-- Dependencies: 223
-- Name: cars_car_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cars_car_id_seq', 1, false);


--
-- TOC entry 4879 (class 0 OID 0)
-- Dependencies: 224
-- Name: failures_failure_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.failures_failure_id_seq', 1, false);


--
-- TOC entry 4880 (class 0 OID 0)
-- Dependencies: 225
-- Name: workshops_workshop_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.workshops_workshop_id_seq', 1, true);


--
-- TOC entry 4701 (class 2606 OID 57433)
-- Name: brigades brigades_brigade_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.brigades
    ADD CONSTRAINT brigades_brigade_name_key UNIQUE (brigade_name);


--
-- TOC entry 4703 (class 2606 OID 57450)
-- Name: brigades brigades_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.brigades
    ADD CONSTRAINT brigades_pkey PRIMARY KEY (brigade_id);


--
-- TOC entry 4689 (class 2606 OID 57388)
-- Name: car_repair car_repair_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.car_repair
    ADD CONSTRAINT car_repair_pkey PRIMARY KEY (car_id, failure_id, arrival_date);


--
-- TOC entry 4697 (class 2606 OID 57437)
-- Name: cars cars_car_body_number_car_engine_number_car_vin_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cars
    ADD CONSTRAINT cars_car_body_number_car_engine_number_car_vin_key UNIQUE (car_body_number) INCLUDE (car_engine_number, car_vin);


--
-- TOC entry 4699 (class 2606 OID 57460)
-- Name: cars cars_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cars
    ADD CONSTRAINT cars_pkey PRIMARY KEY (car_id);


--
-- TOC entry 4691 (class 2606 OID 57435)
-- Name: failures failures_failure_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.failures
    ADD CONSTRAINT failures_failure_name_key UNIQUE (failure_name);


--
-- TOC entry 4693 (class 2606 OID 57470)
-- Name: failures failures_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.failures
    ADD CONSTRAINT failures_pkey PRIMARY KEY (failure_id);


--
-- TOC entry 4679 (class 2606 OID 57518)
-- Name: failures failures_work_cost_check; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public.failures
    ADD CONSTRAINT failures_work_cost_check CHECK ((work_cost >= 0)) NOT VALID;


--
-- TOC entry 4687 (class 2606 OID 57394)
-- Name: personnel personnel_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personnel
    ADD CONSTRAINT personnel_pkey PRIMARY KEY (workshop_id, "person_INN");


--
-- TOC entry 4680 (class 2606 OID 57439)
-- Name: spare_parts spare_parts_part_amount_check; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public.spare_parts
    ADD CONSTRAINT spare_parts_part_amount_check CHECK ((part_amount > 0)) NOT VALID;


--
-- TOC entry 4681 (class 2606 OID 57520)
-- Name: spare_parts spare_parts_part_cost_check; Type: CHECK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE public.spare_parts
    ADD CONSTRAINT spare_parts_part_cost_check CHECK ((part_cost > 0)) NOT VALID;


--
-- TOC entry 4695 (class 2606 OID 57390)
-- Name: spare_parts spare_parts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spare_parts
    ADD CONSTRAINT spare_parts_pkey PRIMARY KEY (car_id, part_name);


--
-- TOC entry 4683 (class 2606 OID 57480)
-- Name: workshops workshops_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workshops
    ADD CONSTRAINT workshops_pkey PRIMARY KEY (workshop_id);


--
-- TOC entry 4685 (class 2606 OID 57431)
-- Name: workshops workshops_workshop_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.workshops
    ADD CONSTRAINT workshops_workshop_name_key UNIQUE (workshop_name);


--
-- TOC entry 4856 (class 2618 OID 57536)
-- Name: number_of_failures_by_cars _RETURN; Type: RULE; Schema: public; Owner: postgres
--

CREATE OR REPLACE VIEW public.number_of_failures_by_cars AS
 SELECT cars.car_id,
    cars.car_vin,
    count(car_repair.failure_id) AS "number of failures"
   FROM (public.cars
     JOIN public.car_repair ON ((cars.car_id = car_repair.car_id)))
  GROUP BY cars.car_id
 HAVING (count(car_repair.failure_id) > 0);


--
-- TOC entry 4706 (class 2606 OID 57512)
-- Name: car_repair car_repair_brigade_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.car_repair
    ADD CONSTRAINT car_repair_brigade_id_fkey FOREIGN KEY (brigade_id) REFERENCES public.brigades(brigade_id) NOT VALID;


--
-- TOC entry 4707 (class 2606 OID 57502)
-- Name: car_repair car_repair_car_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.car_repair
    ADD CONSTRAINT car_repair_car_id_fkey FOREIGN KEY (car_id) REFERENCES public.cars(car_id) NOT VALID;


--
-- TOC entry 4708 (class 2606 OID 57507)
-- Name: car_repair car_repair_failure_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.car_repair
    ADD CONSTRAINT car_repair_failure_id_fkey FOREIGN KEY (failure_id) REFERENCES public.failures(failure_id) NOT VALID;


--
-- TOC entry 4704 (class 2606 OID 57497)
-- Name: personnel personnel_brigade_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personnel
    ADD CONSTRAINT personnel_brigade_id_fkey FOREIGN KEY (brigade_id) REFERENCES public.brigades(brigade_id) NOT VALID;


--
-- TOC entry 4705 (class 2606 OID 57492)
-- Name: personnel personnel_workshop_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personnel
    ADD CONSTRAINT personnel_workshop_id_fkey FOREIGN KEY (workshop_id) REFERENCES public.workshops(workshop_id) NOT VALID;


--
-- TOC entry 4709 (class 2606 OID 57482)
-- Name: spare_parts spare_parts_car_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spare_parts
    ADD CONSTRAINT spare_parts_car_id_fkey FOREIGN KEY (car_id) REFERENCES public.cars(car_id) NOT VALID;


--
-- TOC entry 4710 (class 2606 OID 57487)
-- Name: spare_parts spare_parts_failure_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spare_parts
    ADD CONSTRAINT spare_parts_failure_id_fkey FOREIGN KEY (failure_id) REFERENCES public.failures(failure_id) NOT VALID;


-- Completed on 2024-12-12 00:16:02

--
-- PostgreSQL database dump complete
--

