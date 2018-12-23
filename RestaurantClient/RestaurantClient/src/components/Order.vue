<style>
  @import '../style.css';
</style>
<template>
  <div class="order">
    Input: <input type="text" id="txtInput" v-model="txtInput" />
    Output: <input type="text" id="txtOutput" v-model="txtOutput"/>
    <input type="button" value="Send order" id="btnSend" v-on:click="getOrder" />
    <table>
        <thead>
            <tr>
                <th>Input</th>
                <th>Output</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="h in history">
                <td>{{h.input}}</td>
                <td>{{h.output}}</td>
            </tr>
        </tbody>
    </table>

  </div>
</template>


<script>
import Orders from '../services/orderList';
export default{
    data() {
    return {
      txtInput : '',
      txtOutput:'',
      history:[]
    };
  },
  methods: {
    getOrder () {
        Orders.getOrder(this.txtInput).then(resposta =>{
        this.txtOutput = resposta.data
        var obj={input:this.txtInput, output: this.txtOutput}
        this.history.push(obj)
    })
    }
  }
}
</script>