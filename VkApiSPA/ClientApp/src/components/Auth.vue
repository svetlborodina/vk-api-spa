<template>
  <div class="row">
    <div class="col-xl-6">
      <div class="card">
        <div class="card-body">
          <form @submit.prevent="getCode">
            <div class="form-group">
              <label for="clientId">ClientId</label>
              <input
                type="text"
                class="form-control"
                v-model="auth.clientId"
                id="clientId"
                required
                placeholder="Введите идентификатор клиента"
              />
            </div>
            <div class="form-group">
              <label for="clientId">SecretKey</label>
              <input
                type="text"
                class="form-control"
                v-model="auth.secretKey"
                id="secretKey"
                required
                placeholder="Введите секретный ключ"
              />
            </div>
            <button type="submit" class="btn btn-primary">
              Получить ссылку
            </button>
          </form>
          <br />
          <div v-if="authLink">
            <a target="_blank" v-bind:href="authLink" class="btn btn-secondary">Получить код</a>
          </div>
        </div>
      </div>
      <br />
      <div class="card" v-if="authLink">
        <div class="card-body">
          <form @submit.prevent="getToken">
            <div class="form-group">
              <label for="code">Code</label>
              <input
                type="text"
                class="form-control"
                v-model="auth.code"
                id="code"
                required
                placeholder="Введите код"
              />
            </div>
            <button type="submit" class="btn btn-primary">
              Получить токен
            </button>
          </form>
          <br />
          <div v-if="token">
            {{token}}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: "Auth",
  data() {
    return {
      resources: [],
      auth: {
        clientId: 1,
        secretKey: "secretKey"
      },
      authLink: null,
      token: null
    };
  },
  async mounted() {},
  methods: {
    async getCode() {
      this.authLink = (await axios.get(`/auth/generate?clientId=${this.auth.clientId}`)).data;
    },
    async getToken() {
      this.token = (await axios.get(`/auth/add?clientId=${this.auth.clientId}&secretKey=${this.auth.secretKey}&code=${this.auth.code}`)).data;
    }
  },
}
</script>

<style scoped>
.close {
  text-shadow: 0 1px 0 #000;
  opacity: 1;
}
</style>
