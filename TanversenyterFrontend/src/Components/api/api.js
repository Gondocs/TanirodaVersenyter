import apiConfig from "./apiConfig";

const get = {
  GetAll: () => {
    return apiConfig.get("/User/GetAll").then((response) => response.data);
  },

  GetUserById: (id) => {
    return apiConfig
      .get(`/User/GetUserById/${id}`)
      .then((response) => response.data);
  },

  GetUserById2: (id) => {
    return apiConfig
      .get(`/User/GetUserById`, {
        params: {
          id: id,
        },
      })
      .then((response) => response.data);
  },
};

const post = {
  RegisterData: (data) => {
    return apiConfig
      .post("/Auth/register", data)
      .then((response) => response.data);
  },

  LoginData: (data) => {
    return apiConfig.post("/Auth/login", data).then((response) => {
      const token = response.data;
      return { token };
    });
  },
};

const put = {};

const del = {};

export { get, post, put, del };
