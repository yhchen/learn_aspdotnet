<template>
  用户名：<input type="text" v-model="state.loginData.Username" />
  密码：<input type="password" v-model="state.loginData.Password" />
  <input type="submit" value="登录" @click="loginSubmit" />
  <ul>
    <li v-for="p in state.workingInfos" :key="p.id">
      {{ p.id }} {{ p.name }} {{ p.workingSet }}
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
    const state = reactive({ loginData: { Username: "", Password: "" }, workingInfos: [{ id: 0, name: "", workingSet: "" }], });
    const loginSubmit = async () => {
      const payload = state.loginData;
      console.log(JSON.stringify(state, null, 2));
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
      console.log(JSON.stringify(data));
      state.workingInfos = data.workingInfos;
    }
    return { state, loginSubmit };
  }
});
</script>