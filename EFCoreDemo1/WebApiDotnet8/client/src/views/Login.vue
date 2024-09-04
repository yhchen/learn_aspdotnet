<template>
  用户名：<input type="text" v-md-model="state.loginData.Username" />
  密码：<input type="Password" v-md-model="state.loginData.Password" />
  <input type="submit" value="登录" @click="loginSubmit" />
  <ul>
    <li>
      {{ state.loginData.UserName }} {{ state.loginData.Password }}
    </li>
    <li v-for="p in state.processes" :key="p.id">
      {{ p.id }} {{ p.ProcessName }} {{ p.workingSet64 }}
    </li>
  </ul>
  </input>
</template>
<script>
import { defineComponent, ref } from 'vue';
import axios from 'axios';
import { reactive, onMounted } from 'vue';
export default defineComponent({
  name: 'Login',
  setup() {
    const state = reactive({ loginData: { Username: "", Password: "" }, processes: [{ id: 0, ProcessName: "", workingSet64: "" }], state: {} });
    const loginSubmit = async () => {
      const payload = state.loginData;
      const resp = await axios.post("http://localhost:5265/Login/Login", payload
        , {
          headers: {
            'Content-Type': 'application/json'
          }
        });

      const data = resp.data;
      if (!data.ok) {
        return { state, loginSubmit };
      }
      state.processes = data.processes;
    }
    return { state, loginSubmit };
  }
});
</script>