--
-- PostgreSQL database dump
--

\restrict QePpJAlFHFbnzP4KR9NfyhXGecKpZPZLNKu3bE4t6CrgWa7XvSAM00rgHk7Z8Bh

-- Dumped from database version 18.3
-- Dumped by pg_dump version 18.3

-- Started on 2026-05-01 04:25:25

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
-- TOC entry 236 (class 1259 OID 41215)
-- Name: dogadaji; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dogadaji (
    id integer NOT NULL,
    lokal_id integer,
    organizator_id integer,
    kategorija_id integer,
    naziv character varying(100) NOT NULL,
    vrijeme_pocetka timestamp without time zone NOT NULL,
    opis text,
    url_slike text
);


ALTER TABLE public.dogadaji OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 41214)
-- Name: dogadaji_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.dogadaji_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.dogadaji_id_seq OWNER TO postgres;

--
-- TOC entry 6056 (class 0 OID 0)
-- Dependencies: 235
-- Name: dogadaji_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.dogadaji_id_seq OWNED BY public.dogadaji.id;


--
-- TOC entry 242 (class 1259 OID 41293)
-- Name: favoriti; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.favoriti (
    korisnik_id integer NOT NULL,
    lokal_id integer NOT NULL
);


ALTER TABLE public.favoriti OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 41206)
-- Name: kategorije; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kategorije (
    id integer NOT NULL,
    naziv character varying(50) NOT NULL
);


ALTER TABLE public.kategorije OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 41205)
-- Name: kategorije_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kategorije_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kategorije_id_seq OWNER TO postgres;

--
-- TOC entry 6057 (class 0 OID 0)
-- Dependencies: 233
-- Name: kategorije_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kategorije_id_seq OWNED BY public.kategorije.id;


--
-- TOC entry 226 (class 1259 OID 41147)
-- Name: korisnici; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.korisnici (
    id integer NOT NULL,
    korisnicko_ime character varying(50) NOT NULL,
    ime character varying(50),
    prezime character varying(50),
    email character varying(100) NOT NULL,
    lozinka_hash text NOT NULL,
    datum_registracije timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.korisnici OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 41146)
-- Name: korisnici_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.korisnici_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.korisnici_id_seq OWNER TO postgres;

--
-- TOC entry 6058 (class 0 OID 0)
-- Dependencies: 225
-- Name: korisnici_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.korisnici_id_seq OWNED BY public.korisnici.id;


--
-- TOC entry 241 (class 1259 OID 41275)
-- Name: korisnik_obavijest; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.korisnik_obavijest (
    korisnik_id integer NOT NULL,
    obavijest_id integer NOT NULL,
    procitano boolean DEFAULT false
);


ALTER TABLE public.korisnik_obavijest OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 41165)
-- Name: kvartovi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kvartovi (
    id integer NOT NULL,
    naziv character varying(100) NOT NULL
);


ALTER TABLE public.kvartovi OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 41164)
-- Name: kvartovi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kvartovi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kvartovi_id_seq OWNER TO postgres;

--
-- TOC entry 6059 (class 0 OID 0)
-- Dependencies: 227
-- Name: kvartovi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kvartovi_id_seq OWNED BY public.kvartovi.id;


--
-- TOC entry 230 (class 1259 OID 41174)
-- Name: lokali; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lokali (
    id integer NOT NULL,
    kvart_id integer,
    naziv character varying(100) NOT NULL,
    adresa text,
    lat double precision,
    lng double precision,
    radno_vrijeme text,
    opis text,
    ima_pusenje boolean DEFAULT false,
    ima_biljar boolean DEFAULT false,
    ima_pikado boolean DEFAULT false,
    url_cjenik text,
    is_premium boolean DEFAULT false,
    url_slika character varying(500) DEFAULT ''::character varying
);


ALTER TABLE public.lokali OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 41173)
-- Name: lokali_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.lokali_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.lokali_id_seq OWNER TO postgres;

--
-- TOC entry 6060 (class 0 OID 0)
-- Dependencies: 229
-- Name: lokali_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.lokali_id_seq OWNED BY public.lokali.id;


--
-- TOC entry 238 (class 1259 OID 41242)
-- Name: obavijesti; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.obavijesti (
    id integer NOT NULL,
    naslov character varying(100),
    sadrzaj text NOT NULL,
    datum_slanja timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.obavijesti OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 41241)
-- Name: obavijesti_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.obavijesti_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.obavijesti_id_seq OWNER TO postgres;

--
-- TOC entry 6061 (class 0 OID 0)
-- Dependencies: 237
-- Name: obavijesti_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.obavijesti_id_seq OWNED BY public.obavijesti.id;


--
-- TOC entry 232 (class 1259 OID 41195)
-- Name: organizatori; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.organizatori (
    id integer NOT NULL,
    naziv character varying(100) NOT NULL,
    opis text,
    kontakt_email character varying(100)
);


ALTER TABLE public.organizatori OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 41194)
-- Name: organizatori_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.organizatori_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.organizatori_id_seq OWNER TO postgres;

--
-- TOC entry 6062 (class 0 OID 0)
-- Dependencies: 231
-- Name: organizatori_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.organizatori_id_seq OWNED BY public.organizatori.id;


--
-- TOC entry 240 (class 1259 OID 41254)
-- Name: popusti; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.popusti (
    id integer NOT NULL,
    lokal_id integer,
    korisnik_id integer,
    naslov character varying(100),
    opis_popusta text NOT NULL,
    iskoristenost boolean DEFAULT false,
    vrijedi_do timestamp without time zone
);


ALTER TABLE public.popusti OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 41253)
-- Name: popusti_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.popusti_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.popusti_id_seq OWNER TO postgres;

--
-- TOC entry 6063 (class 0 OID 0)
-- Dependencies: 239
-- Name: popusti_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.popusti_id_seq OWNED BY public.popusti.id;


--
-- TOC entry 244 (class 1259 OID 41311)
-- Name: recenzije; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.recenzije (
    id integer NOT NULL,
    korisnik_id integer,
    lokal_id integer,
    ocjena integer,
    komentar text,
    datum_objave timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT recenzije_ocjena_check CHECK (((ocjena >= 1) AND (ocjena <= 5)))
);


ALTER TABLE public.recenzije OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 41310)
-- Name: recenzije_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.recenzije_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.recenzije_id_seq OWNER TO postgres;

--
-- TOC entry 6064 (class 0 OID 0)
-- Dependencies: 243
-- Name: recenzije_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.recenzije_id_seq OWNED BY public.recenzije.id;


--
-- TOC entry 5828 (class 2604 OID 41218)
-- Name: dogadaji id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dogadaji ALTER COLUMN id SET DEFAULT nextval('public.dogadaji_id_seq'::regclass);


--
-- TOC entry 5827 (class 2604 OID 41209)
-- Name: kategorije id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategorije ALTER COLUMN id SET DEFAULT nextval('public.kategorije_id_seq'::regclass);


--
-- TOC entry 5817 (class 2604 OID 41150)
-- Name: korisnici id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnici ALTER COLUMN id SET DEFAULT nextval('public.korisnici_id_seq'::regclass);


--
-- TOC entry 5819 (class 2604 OID 41168)
-- Name: kvartovi id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kvartovi ALTER COLUMN id SET DEFAULT nextval('public.kvartovi_id_seq'::regclass);


--
-- TOC entry 5820 (class 2604 OID 41177)
-- Name: lokali id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lokali ALTER COLUMN id SET DEFAULT nextval('public.lokali_id_seq'::regclass);


--
-- TOC entry 5829 (class 2604 OID 41245)
-- Name: obavijesti id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.obavijesti ALTER COLUMN id SET DEFAULT nextval('public.obavijesti_id_seq'::regclass);


--
-- TOC entry 5826 (class 2604 OID 41198)
-- Name: organizatori id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.organizatori ALTER COLUMN id SET DEFAULT nextval('public.organizatori_id_seq'::regclass);


--
-- TOC entry 5831 (class 2604 OID 41257)
-- Name: popusti id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.popusti ALTER COLUMN id SET DEFAULT nextval('public.popusti_id_seq'::regclass);


--
-- TOC entry 5834 (class 2604 OID 41314)
-- Name: recenzije id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recenzije ALTER COLUMN id SET DEFAULT nextval('public.recenzije_id_seq'::regclass);


--
-- TOC entry 6041 (class 0 OID 41215)
-- Dependencies: 236
-- Data for Name: dogadaji; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.dogadaji (id, lokal_id, organizator_id, kategorija_id, naziv, vrijeme_pocetka, opis, url_slike) FROM stdin;
5	9	3	1	Good Vibrations: Stoner Rock	2026-05-21 21:00:00	Teški rifovi i hladno pivo u Vintage-u.	https://images.unsplash.com/photo-1501386761578-eac5c94b800a
6	1	3	1	Akustična večer: Live	2026-05-14 20:30:00	Lagana svirka na terasi uz Vlašku.	https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4
2	4	1	3	Gala Mrav: Opći Kviz	2026-05-20 19:30:00	Najpopularniji kviz na Trešnjevci. Prijave u DM!	https://iks-portal.info/media/k2/items/cache/1ec2a12723aafca982d5b879ea870cbd_L.jpg
3	2	2	2	Sentiš: Plesnjak u Alcatrazu	2026-05-16 22:00:00	Samo domaće, samo lagano i samo hitovi.	https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/43/6c/fd/the-club.jpg?w=1200&h=900&s=1
4	8	2	2	Sentiš na Savi	2026-05-22 23:00:00	Trash party 90-ih uz jezero Jarun.	https://media.phillyvoice.com/media/images/iStock-641775168.2e16d0ba.fill-735x490.jpg
7	10	4	4	Lajnap: Best of Stand-up	2026-05-18 20:30:00	Večer novog materijala u Oliver Twistu.	https://img.freepik.com/free-vector/stand-up-comedy-banner-with-vintage-microphone_1308-80026.jpg?semt=ais_hybrid&w=740&q=80
8	7	5	2	BSH: Jarun Lake Session	2026-05-24 16:00:00	Day party uz vrhunski house na Aquarius terasi.	https://cdn.entr.io/images/events/253/25317_poster_900x1200.png?v=1747850474
9	5	1	5	Karaoke: Kvak edition	2026-05-19 21:00:00	Pjevamo dok nas ne istjeraju.	https://t4.ftcdn.net/jpg/02/01/77/03/360_F_201770379_ejWO8LSnZ3BCk54BkXRGPOgcmljjEvmi.jpg
10	3	3	6	Gledanje: Dinamo - Osijek	2026-05-23 19:00:00	Svi u Bikers na derbi kola!	https://t4.ftcdn.net/jpg/07/08/35/37/360_F_708353784_PXK9TC1zAvVDto8ijJlEr5656sdUcTOU.jpg
1	3	1	3	Gala Mrav: Glazbeni Kviz	2026-05-15 20:00:00	Prepoznaj intro u 5 sekundi i osvoji gajbu piva!	https://www.spinningwheelinn.co.uk/wp-content/uploads/2023/02/pub-quiz.jpg
\.


--
-- TOC entry 6047 (class 0 OID 41293)
-- Dependencies: 242
-- Data for Name: favoriti; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.favoriti (korisnik_id, lokal_id) FROM stdin;
\.


--
-- TOC entry 6039 (class 0 OID 41206)
-- Dependencies: 234
-- Data for Name: kategorije; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kategorije (id, naziv) FROM stdin;
1	Live Glazba
2	DJ Party
3	Pub Kviz
4	Stand-up Komedija
5	Karaoke
6	Sportska Gledanja
\.


--
-- TOC entry 6031 (class 0 OID 41147)
-- Dependencies: 226
-- Data for Name: korisnici; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.korisnici (id, korisnicko_ime, ime, prezime, email, lozinka_hash, datum_registracije) FROM stdin;
1	ana_t	Ana	Teslić	ana@test.com	lozinka123	2026-04-30 14:09:43.822283
2	marko_zg	Marko	Horvat	marko@test.com	lozinka456	2026-04-30 14:24:47.366165
3	prijateljica_m	Marta	Ivić	marta@test.com	lozinka789	2026-04-30 14:24:47.366165
4	leonarda_j	leonarda	jakić	leonarda@test.com	$2a$11$atGfdWWGNORWe5uq1c3ceeATyYzcRkUroN1qrAdVO9Eik3L25xNce	2026-05-01 01:09:37.66973
5	paula_n	paula	nikolic	paula@test.com	$2a$11$8NA320LMOv/eTXs1hh5QWu3X8N/Wc9VKvynjh6677ZbRKWN3tgJQa	2026-05-01 03:56:46.107157
6	lovro_p	lovro	peric	lovro@test.com	$2a$11$TJxrGchh/Z3m76A/ICBt0u0./H6biyNfgfAHMBug0Dkl3yzsDRb0a	2026-05-01 03:58:28.990889
7	marko_k	marko	katic	marko.katic@test.com	$2a$11$GjWHbPSPNI.To5uT2nAyKeI54Uw4QyTjnyHpHMJngfb6bbJf72VCm	2026-05-01 04:07:10.058417
8	bruna_v	bruna	vlatkovic	bruna.vlatkovic@test.com	$2a$11$B81.YYO6mV5fw3IP.rQNi.InYnoENqL.C7iNRjugGf77//hTt2lqu	2026-05-01 04:09:00.015325
\.


--
-- TOC entry 6046 (class 0 OID 41275)
-- Dependencies: 241
-- Data for Name: korisnik_obavijest; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.korisnik_obavijest (korisnik_id, obavijest_id, procitano) FROM stdin;
\.


--
-- TOC entry 6033 (class 0 OID 41165)
-- Dependencies: 228
-- Data for Name: kvartovi; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kvartovi (id, naziv) FROM stdin;
1	Trešnjevka
2	Centar
3	Maksimir
4	Jarun
\.


--
-- TOC entry 6035 (class 0 OID 41174)
-- Dependencies: 230
-- Data for Name: lokali; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.lokali (id, kvart_id, naziv, adresa, lat, lng, radno_vrijeme, opis, ima_pusenje, ima_biljar, ima_pikado, url_cjenik, is_premium, url_slika) FROM stdin;
1	2	Caffe Bar Finjak	Vlaška ul. 78	45.8144	15.989	08-23h	Najljepša terasa u gradu s vintage ugođajem.	f	f	f	\N	t	https://images.unsplash.com/photo-1554118811-1e0d58224f24
2	2	Alcatraz	Preradovićeva ul. 12	45.811	15.9755	07-04h	Legendarni zagrebački rock bar na tri kata.	t	f	f	\N	f	https://images.unsplash.com/photo-1514933651103-005eec06c04b
5	3	Caffe Bar Kvak	Martićeva ul. 71	45.813	15.993	07-23h	Kvartovski kafić s dugom tradicijom i najboljom kavom.	t	f	t	\N	f	https://images.unsplash.com/photo-1501339847302-ac426a4a7cbb
6	3	Eggspress	Vlaška ul. 81	45.8148	15.991	08-18h	Specijalizirani bar za doručak i brunch uz park.	f	f	f	\N	t	https://images.unsplash.com/photo-1481833761820-0509d3217039
7	4	Aquarius	Aleja Matije Ljubeka bb	45.7775	15.922	09-04h	Klub i kafić na samom jezeru, idealno za ljetne večeri.	f	f	f	\N	t	https://images.unsplash.com/photo-1574096079513-d8259312b785
9	1	Vintage Industrial Bar	Savska cesta 160	45.79	15.958	09-01h	Kultno mjesto za koncerte, biljar i najbolje craft pivo.	t	t	t	\N	t	https://www.waynesbar-restaurant.com/media/images/gallery/2/big/42.jpg?1775692800023
4	1	Caffe Bar Hub 22	Tratinska 22	45.8035	15.9555	07-23h	Moderni industrijski dizajn, savršeno za rad na laptopu.	f	f	f	\N	f	https://possector.hr/wp-content/uploads/2024/10/kako-otvoriti-caffe-bar.png
3	1	Bikers Beer Factory	Savska cesta 150	45.7915	15.9595	08-02h	Veliki prostor, odlično pivo i živa glazba.	t	t	t	\N	t	https://www.milwaukeemag.com/wp-content/uploads/2018/11/DraftVessel-1-1024x683.jpg
10	2	Oliver Twist	Tkalčićeva 60	45.8165	15.976	08-00h	Pub u srcu Tkalče s ogromnim izborom piva.	t	f	f	\N	f	https://media-cdn.holidaycheck.com/w_768,h_432,c_fill,q_auto,f_auto/ugc/images/d289b72d-dbf8-3eeb-a7dd-7ff61d32d4a4
8	4	Žiraffa	Horvaćanska cesta 31	45.785	15.938	08-23h	Povoljne cijene i uvijek vesela atmosfera blizu Save.	t	t	f	\N	f	https://images.pexels.com/photos/5858069/pexels-photo-5858069.jpeg
\.


--
-- TOC entry 6043 (class 0 OID 41242)
-- Dependencies: 238
-- Data for Name: obavijesti; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.obavijesti (id, naslov, sadrzaj, datum_slanja) FROM stdin;
\.


--
-- TOC entry 6037 (class 0 OID 41195)
-- Dependencies: 232
-- Data for Name: organizatori; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.organizatori (id, naziv, opis, kontakt_email) FROM stdin;
1	Gala Mrav	Najpoznatiji zagrebački pub kvizovi s vrhunskom atmosferom.	kviz@galamrav.hr
2	Sentiš	Instagram party kolektiv fokusiran na trash i ex-yu hitove.	ples@sentis.hr
3	Good Vibrations	Program koji promovira live bendove i klupske svirke.	info@goodvibrations.hr
4	Lajnap Comedy	Stand-up kolektiv koji puni klubove širom Zagreba.	upadi@lajnap.hr
5	BSH Events	Vodeći organizatori house i techno partyja na unikatnim lokacijama.	info@bshevents.com
\.


--
-- TOC entry 6045 (class 0 OID 41254)
-- Dependencies: 240
-- Data for Name: popusti; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.popusti (id, lokal_id, korisnik_id, naslov, opis_popusta, iskoristenost, vrijedi_do) FROM stdin;
\.


--
-- TOC entry 6049 (class 0 OID 41311)
-- Dependencies: 244
-- Data for Name: recenzije; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.recenzije (id, korisnik_id, lokal_id, ocjena, komentar, datum_objave) FROM stdin;
1	1	1	5	Najljepša terasa u gradu i super kava!	2026-04-30 14:10:39.906198
2	1	2	4	Alcatraz je klasik, uvijek dobra ekipa.	2026-04-30 14:10:39.906198
3	2	1	3	Kava je okej, ali konobar je bio malo spor danas.	2026-04-30 14:25:04.250339
4	3	1	5	Obožavam ovaj prostor, uvijek se vratim kad sam u kvartu.	2026-04-30 14:25:04.250339
\.

--
-- TOC entry 6065 (class 0 OID 0)
-- Dependencies: 235
-- Name: dogadaji_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.dogadaji_id_seq', 10, true);


--
-- TOC entry 6066 (class 0 OID 0)
-- Dependencies: 233
-- Name: kategorije_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kategorije_id_seq', 6, true);


--
-- TOC entry 6067 (class 0 OID 0)
-- Dependencies: 225
-- Name: korisnici_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.korisnici_id_seq', 8, true);


--
-- TOC entry 6068 (class 0 OID 0)
-- Dependencies: 227
-- Name: kvartovi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kvartovi_id_seq', 4, true);


--
-- TOC entry 6069 (class 0 OID 0)
-- Dependencies: 229
-- Name: lokali_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.lokali_id_seq', 10, true);


--
-- TOC entry 6070 (class 0 OID 0)
-- Dependencies: 237
-- Name: obavijesti_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.obavijesti_id_seq', 1, false);


--
-- TOC entry 6071 (class 0 OID 0)
-- Dependencies: 231
-- Name: organizatori_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.organizatori_id_seq', 5, true);


--
-- TOC entry 6072 (class 0 OID 0)
-- Dependencies: 239
-- Name: popusti_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.popusti_id_seq', 1, false);


--
-- TOC entry 6073 (class 0 OID 0)
-- Dependencies: 243
-- Name: recenzije_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.recenzije_id_seq', 4, true);


--
-- TOC entry 5855 (class 2606 OID 41225)
-- Name: dogadaji dogadaji_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dogadaji
    ADD CONSTRAINT dogadaji_pkey PRIMARY KEY (id);


--
-- TOC entry 5863 (class 2606 OID 41299)
-- Name: favoriti favoriti_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.favoriti
    ADD CONSTRAINT favoriti_pkey PRIMARY KEY (korisnik_id, lokal_id);


--
-- TOC entry 5853 (class 2606 OID 41213)
-- Name: kategorije kategorije_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategorije
    ADD CONSTRAINT kategorije_pkey PRIMARY KEY (id);


--
-- TOC entry 5841 (class 2606 OID 41163)
-- Name: korisnici korisnici_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnici
    ADD CONSTRAINT korisnici_email_key UNIQUE (email);


--
-- TOC entry 5843 (class 2606 OID 41161)
-- Name: korisnici korisnici_korisnicko_ime_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnici
    ADD CONSTRAINT korisnici_korisnicko_ime_key UNIQUE (korisnicko_ime);


--
-- TOC entry 5845 (class 2606 OID 41159)
-- Name: korisnici korisnici_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnici
    ADD CONSTRAINT korisnici_pkey PRIMARY KEY (id);


--
-- TOC entry 5861 (class 2606 OID 41282)
-- Name: korisnik_obavijest korisnik_obavijest_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnik_obavijest
    ADD CONSTRAINT korisnik_obavijest_pkey PRIMARY KEY (korisnik_id, obavijest_id);


--
-- TOC entry 5847 (class 2606 OID 41172)
-- Name: kvartovi kvartovi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kvartovi
    ADD CONSTRAINT kvartovi_pkey PRIMARY KEY (id);


--
-- TOC entry 5849 (class 2606 OID 41188)
-- Name: lokali lokali_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lokali
    ADD CONSTRAINT lokali_pkey PRIMARY KEY (id);


--
-- TOC entry 5857 (class 2606 OID 41252)
-- Name: obavijesti obavijesti_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.obavijesti
    ADD CONSTRAINT obavijesti_pkey PRIMARY KEY (id);


--
-- TOC entry 5851 (class 2606 OID 41204)
-- Name: organizatori organizatori_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.organizatori
    ADD CONSTRAINT organizatori_pkey PRIMARY KEY (id);


--
-- TOC entry 5859 (class 2606 OID 41264)
-- Name: popusti popusti_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.popusti
    ADD CONSTRAINT popusti_pkey PRIMARY KEY (id);


--
-- TOC entry 5865 (class 2606 OID 41321)
-- Name: recenzije recenzije_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recenzije
    ADD CONSTRAINT recenzije_pkey PRIMARY KEY (id);


--
-- TOC entry 5867 (class 2606 OID 41236)
-- Name: dogadaji dogadaji_kategorija_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dogadaji
    ADD CONSTRAINT dogadaji_kategorija_id_fkey FOREIGN KEY (kategorija_id) REFERENCES public.kategorije(id) ON DELETE SET NULL;


--
-- TOC entry 5868 (class 2606 OID 41226)
-- Name: dogadaji dogadaji_lokal_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dogadaji
    ADD CONSTRAINT dogadaji_lokal_id_fkey FOREIGN KEY (lokal_id) REFERENCES public.lokali(id) ON DELETE CASCADE;


--
-- TOC entry 5869 (class 2606 OID 41231)
-- Name: dogadaji dogadaji_organizator_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dogadaji
    ADD CONSTRAINT dogadaji_organizator_id_fkey FOREIGN KEY (organizator_id) REFERENCES public.organizatori(id) ON DELETE SET NULL;


--
-- TOC entry 5874 (class 2606 OID 41300)
-- Name: favoriti favoriti_korisnik_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.favoriti
    ADD CONSTRAINT favoriti_korisnik_id_fkey FOREIGN KEY (korisnik_id) REFERENCES public.korisnici(id) ON DELETE CASCADE;


--
-- TOC entry 5875 (class 2606 OID 41305)
-- Name: favoriti favoriti_lokal_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.favoriti
    ADD CONSTRAINT favoriti_lokal_id_fkey FOREIGN KEY (lokal_id) REFERENCES public.lokali(id) ON DELETE CASCADE;


--
-- TOC entry 5872 (class 2606 OID 41283)
-- Name: korisnik_obavijest korisnik_obavijest_korisnik_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnik_obavijest
    ADD CONSTRAINT korisnik_obavijest_korisnik_id_fkey FOREIGN KEY (korisnik_id) REFERENCES public.korisnici(id) ON DELETE CASCADE;


--
-- TOC entry 5873 (class 2606 OID 41288)
-- Name: korisnik_obavijest korisnik_obavijest_obavijest_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.korisnik_obavijest
    ADD CONSTRAINT korisnik_obavijest_obavijest_id_fkey FOREIGN KEY (obavijest_id) REFERENCES public.obavijesti(id) ON DELETE CASCADE;


--
-- TOC entry 5866 (class 2606 OID 41189)
-- Name: lokali lokali_kvart_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lokali
    ADD CONSTRAINT lokali_kvart_id_fkey FOREIGN KEY (kvart_id) REFERENCES public.kvartovi(id) ON DELETE SET NULL;


--
-- TOC entry 5870 (class 2606 OID 41270)
-- Name: popusti popusti_korisnik_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.popusti
    ADD CONSTRAINT popusti_korisnik_id_fkey FOREIGN KEY (korisnik_id) REFERENCES public.korisnici(id) ON DELETE CASCADE;


--
-- TOC entry 5871 (class 2606 OID 41265)
-- Name: popusti popusti_lokal_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.popusti
    ADD CONSTRAINT popusti_lokal_id_fkey FOREIGN KEY (lokal_id) REFERENCES public.lokali(id) ON DELETE CASCADE;


--
-- TOC entry 5876 (class 2606 OID 41322)
-- Name: recenzije recenzije_korisnik_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recenzije
    ADD CONSTRAINT recenzije_korisnik_id_fkey FOREIGN KEY (korisnik_id) REFERENCES public.korisnici(id) ON DELETE SET NULL;


--
-- TOC entry 5877 (class 2606 OID 41327)
-- Name: recenzije recenzije_lokal_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.recenzije
    ADD CONSTRAINT recenzije_lokal_id_fkey FOREIGN KEY (lokal_id) REFERENCES public.lokali(id) ON DELETE CASCADE;


-- Completed on 2026-05-01 04:25:26

--
-- PostgreSQL database dump complete
--

\unrestrict QePpJAlFHFbnzP4KR9NfyhXGecKpZPZLNKu3bE4t6CrgWa7XvSAM00rgHk7Z8Bh

