const API_BASE = "http://localhost:5120/api/boeken";

export async function fetchBoeken() {
  try {
    const response = await fetch(API_BASE);
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching boeken:", error);
    throw error;
  }
}

export async function voegBoekToe(boek) {
  try {
    const response = await fetch(API_BASE, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(boek),
    });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
  } catch (error) {
    console.error("Error adding boek:", error);
    throw error;
  }
}

export async function verwijderBoek(id) {
  try {
    const response = await fetch(`${API_BASE}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
  } catch (error) {
    console.error("Error deleting boek:", error);
    throw error;
  }
}

export async function toggleUitgeleend(id) {
  try {
    const response = await fetch(`${API_BASE}/${id}/toggle-uitgeleend`, {
      method: "PUT",
    });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
  } catch (error) {
    console.error("Error toggling uitgeleend status:", error);
    throw error;
  }
}
