import axios from "axios";

axios.interceptors.request.use(
  function(config) {
    config.params = { ...config.params, key: process.env.VUE_APP_BOOKS_KEY };
    return config;
  },
  function(error) {
    return Promise.reject(error);
  }
);

const baseURL = `https://www.googleapis.com/books/v1`;

export async function fetchAllBooks(category = "magic") {
  try {
    const res = await axios.get(`${baseURL}/volumes`, {
      params: {
        q: category,
        maxResults: 40,
        startIndex: 1,
      },
    });
    return res.data.items;
  } catch (e) {
    console.error("Unexpected error while loading books", e);
    return [];
  }
}

export async function fetchSingleBook(bookId) {
  try {
    const res = await axios.get(`${baseURL}/volumes/${bookId}`);
    return res.data;
  } catch (e) {
    console.error("Unexpected error while loading book", e);
    return [];
  }
}


export async function fetchFavouriteBooks() {
  try {
    const res = await axios.get(`${baseURL}/users/${process.env.VUE_APP_BOOKS_USER_ID}/bookshelves/0/volumes`);
    return res.data;
  } catch (e) {
    console.error("Unexpected error while loading book", e);
    return [];
  }
}

export async function fetchReadingBooks() {
  try {
    const res = await axios.get(`${baseURL}/users/${process.env.VUE_APP_BOOKS_USER_ID}/bookshelves/3/volumes`);
    return res.data;
  } catch (e) {
    console.error("Unexpected error while loading book", e);
    return [];
  }
}