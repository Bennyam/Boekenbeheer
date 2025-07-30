import {
  fetchBoeken,
  voegBoekToe,
  verwijderBoek,
  toggleUitgeleend,
} from "./api.js";
import { toonBoeken } from "./ui.js";

export async function laadEnToonBoeken() {
  try {
    const boeken = await fetchBoeken();
    toonBoeken(boeken);
  } catch (error) {
    alert("Fout bij het laden van boeken:", error);
  }
}

export async function handleFormInzending(formElement) {
  const boek = {
    titel: formElement.titel.value,
    auteur: formElement.auteur.value,
    isbn: formElement.isbn.value,
    aantalPaginas: formElement.paginas.value,
    publicatieDatum: formElement.datum.value,
  };

  try {
    await voegBoekToe(boek);
    formElement.reset();
    await laadEnToonBoeken();
  } catch {
    alert("Boek toevoegen mislukt.");
  }
}

export async function handleVerwijder(id) {
  if (!confirm("Weet je zeker dat je dit boek wilt verwijderen?")) return;

  try {
    await verwijderBoek(id);
    await laadEnToonBoeken();
  } catch (error) {
    alert("Fout bij het verwijderen van het boek:", error);
  }
}

export async function handleToggleStatus(id) {
  try {
    await toggleUitgeleend(id);
    await laadEnToonBoeken();
  } catch (error) {
    alert("Fout bij het wijzigen van de status:", error);
  }
}
