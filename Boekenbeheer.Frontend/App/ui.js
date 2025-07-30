import {
  laadEnToonBoeken,
  handleFormInzending,
  handleVerwijder,
  handleToggleStatus,
} from "./logic.js";

const boekenLijst = document.getElementById("boeken-lijst");
const boekForm = document.getElementById("boek-form");

function renderBoek(boek) {
  const li = document.createElement("li");

  const info = document.createElement("span");
  info.innerHTML = `<strong>${boek.titel}</strong> door ${boek.auteur}<br/>
  (ISBN: ${boek.isbn}) - ${boek.aantalPaginas} pagina's<br/> 
  Gepubliceerd op ${boek.publicatieDatum.substring(0, 10)}<br/>
  <span class="status">${
    boek.isUitgeleend ? "Uitgeleend" : "Beschikbaar"
  }</span>`;

  const actions = document.createElement("div");
  actions.classList.add("actions");

  const deleteBtn = document.createElement("button");
  deleteBtn.textContent = "Verwijder";
  deleteBtn.addEventListener("click", () => handleVerwijder(boek.id));

  const toggleBtn = document.createElement("button");
  toggleBtn.textContent = boek.isUitgeleend ? "Terugbrengen" : "Uitlenen";
  toggleBtn.addEventListener("click", () => handleToggleStatus(boek.id));

  actions.appendChild(toggleBtn);
  actions.appendChild(deleteBtn);

  li.appendChild(info);
  li.appendChild(actions);
  boekenLijst.appendChild(li);
}

export function toonBoeken(boeken) {
  boekenLijst.innerHTML = "";
  boeken.forEach(renderBoek);
}

boekForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  await handleFormInzending(boekForm);
});

laadEnToonBoeken();
