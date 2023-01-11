:root {
  /* colors */
  --background: #0e0e0e;
  --foreground: #F1F1F1;
  /* fonts */
  --font-family: Roboto, sans-serif;
  --base-font-size: 18px;
  --font-weight-normal: 400;
  --font-weight-bold: 700; }

/* to download a different font locally:
      https://google-webfonts-helper.herokuapp.com/fonts */
@font-face {
  font-family: Roboto;
  font-style: normal;
  font-weight: 400;
  src: local("Lato Regular"), local("Roboto-Regular"), url("../assets/fonts/roboto-regular.woff2") format("woff2"), url("../assets/fonts/Roboto-Regular.woff") format("woff"); }

@font-face {
  font-family: Roboto;
  font-style: normal;
  font-weight: 900;
  src: local("Roboto Black"), local("Roboto-Black"), url("../assets/fonts/Roboto-Black.woff2") format("woff2"), url("../assets/fonts/roboto-black.woff") format("woff"); }

* {
  box-sizing: border-box; }

html {
  font-family: var(--font-family);
  font-size: var(--base-font-size);
  font-weight: var(--font-weight-normal); }

body {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  margin: 0;
  padding: 0;
  transition: background 0.2s;
  color: var(--foreground); }

input,
button {
  display: block;
  width: 100%;
  margin: 0;
  padding: 0;
  background: transparent;
  color: inherit;
  font-family: var(--font-family);
  font-size: 1rem; }

input,
input:focus {
  border: 0;
  outline: 0; }

ul,
li {
  margin: 0;
  padding: 0;
  list-style: none; }

a,
a:focus {
  color: inherit;
  outline: 0; }

.center {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%; }

.overlay {
  position: fixed;
  top: 0;
  left: 0;
  overflow: auto;
  width: 100%;
  height: 100%;
  visibility: hidden; }

.clock {
  display: block;
  margin-top: -0.06rem;
  font-size: 4rem;
  font-weight: var(--font-weight-normal);
  text-align: center;
  letter-spacing: 0.05rem;
  cursor: pointer; }

.search-form {
  background: var(--foreground);
  color: var(--background);
  z-index: 2; }

.search-form > div {
  width: 100%; }

.search-input {
  width: 100%;
  padding: 0 1rem;
  margin-bottom: 20px;
  font-size: 1.5rem;
  font-weight: var(--font-weight-bold);
  letter-spacing: 0.1rem;
  text-transform: uppercase;
  color: white; }

.search-suggestions {
  display: none;
  justify-content: center;
  flex-direction: column;
  flex-wrap: wrap;
  overflow: hidden; }

body.suggestions .search-suggestions {
  display: flex; }

.search-suggestion {
  border-width: 0px;
  padding: 0.75rem 1rem;
  text-align: left;
  white-space: nowrap;
  cursor: pointer;
  color: white; }

.search-suggestion.highlight {
  background: var(--background);
  color: var(--foreground); }

.search-suggestion b {
  position: relative;
  font-weight: var(--font-weight-normal);
  color: white; }

.search-suggestion b::after {
  content: ' ';
  position: absolute;
  right: 0;
  bottom: -0.3rem;
  left: 0;
  height: 2px;
  background: var(--background);
  opacity: 0.4;
  color: white; }

.search-suggestion.highlight b::after {
  opacity: 0; }

.help {
  display: block;
  padding: 8vw;
  background: var(--background);
  z-index: 1; }

.category {
  margin-bottom: 3rem;
  padding: 25px;
  width: 250px;
  min-width: 225px; }

.category-name {
  margin-bottom: 1.5rem;
  font-size: 0.75rem;
  letter-spacing: 0.15rem;
  text-transform: uppercase; }

.command a {
  display: flex;
  position: relative;
  margin: 1rem 0;
  line-height: 2rem;
  text-decoration: none; }

.command:last-of-type a {
  margin-bottom: 0; }

.command-key {
  display: block;
  float: left;
  width: 2rem;
  height: 2rem;
  margin-right: 1rem;
  border-radius: 50%;
  background: transparent;
  color: var(--background);
  font-size: 0.75rem;
  line-height: 2rem;
  text-align: center; }

.command-name {
  position: relative; }

.command-name::after {
  content: ' ';
  display: none;
  position: absolute;
  right: 0;
  bottom: 2px;
  left: 0;
  height: 2px;
  transition: 0.2s;
  transform: translateX(-2rem);
  background: var(--foreground);
  opacity: 0; }

body.help .command-name::after {
  display: block; }

.command a:hover .command-name::after,
.command a:focus .command-name::after {
  transform: translateX(0);
  opacity: 1; }

body.help .help,
body.form .search-form {
  visibility: visible; }

@media (min-width: 500px) {
  .clock {
    font-size: 6rem; }
  .search-input {
    text-align: center; }
  .search-suggestions {
    align-items: center; }
  .categories {
    display: flex;
    grid-template-columns: 250px 175px;
    justify-content: space-around; }
  .category:nth-last-child(2) {
    margin-bottom: 0; } }

@media (min-width: 1000px) {
  .help {
    display: flex;
    padding: 0; }
  .search-input {
    font-size: 2.5rem; }
  .search-suggestions {
    flex-direction: row;
    color: white; }
  .category {
    margin: 2rem 0; }
  .categories {
    grid-template-columns: repeat(2, 300px) 175px; } }

@media (min-width: 1500px) {
  .categories {
    grid-template-columns: repeat(5, 220px) 175px; } }
