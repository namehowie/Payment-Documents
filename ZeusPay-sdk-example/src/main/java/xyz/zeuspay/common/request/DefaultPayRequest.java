package xyz.zeuspay.common.request;

import com.alibaba.fastjson.JSONObject;
import com.google.common.base.Preconditions;
import lombok.AllArgsConstructor;
import lombok.Data;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.config.RequestConfig;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.config.RegistryBuilder;
import org.apache.http.conn.socket.ConnectionSocketFactory;
import org.apache.http.conn.socket.PlainConnectionSocketFactory;
import org.apache.http.conn.ssl.SSLConnectionSocketFactory;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.HttpClientBuilder;
import org.apache.http.impl.conn.BasicHttpClientConnectionManager;
import org.apache.http.util.EntityUtils;
import xyz.zeuspay.common.config.ZeusPayConfig;
import xyz.zeuspay.common.util.SignUtil;

import java.util.Map;

import static xyz.zeuspay.common.util.SignUtil.USER_AGENT;

/**
 * 默认的支付请求
 * 
 * @Description
 * @author wuys
 * @date 2017年9月29日 下午3:23:57
 */
@Data
@AllArgsConstructor
public class DefaultPayRequest {

    private ZeusPayConfig zeusPayConfig;


    /**
     * 执行请求
     * @param requestUrl
     * @param data
     * @param connectTimeoutMs
     * @param readTimeoutMs
     * @return
     * @throws Exception
     */
    public String postExecute(String requestUrl, Map<String,String> data, int connectTimeoutMs,
                              int readTimeoutMs) throws Exception {
        Preconditions.checkArgument(requestUrl != null || data != null,"request url and data can not be null!please check your params!",requestUrl,data,connectTimeoutMs,readTimeoutMs);
        String sign = SignUtil.generateSignature(data,zeusPayConfig.getSignKey(), SignUtil.SignType.MD5);
        data.put(SignUtil.FIELD_SIGN,sign);
        return requestWithoutCert(requestUrl, JSONObject.toJSONString(data),connectTimeoutMs,readTimeoutMs);
    }

    /**
     * 传输json数据
     * 
     * @param requestUrl
     * @param data
     * @param connectTimeoutMs
     * @param readTimeoutMs
     * @return
     * @throws Exception
     */
    private String requestWithoutCert(String requestUrl, String data, int connectTimeoutMs, int readTimeoutMs)
            throws Exception {
        BasicHttpClientConnectionManager connManager = new BasicHttpClientConnectionManager(RegistryBuilder
                .<ConnectionSocketFactory> create().register("http", PlainConnectionSocketFactory.getSocketFactory())
                .register("https", SSLConnectionSocketFactory.getSocketFactory()).build(), null, null, null);
        HttpClient httpClient = HttpClientBuilder.create().setConnectionManager(connManager).build();

        HttpPost httpPost = new HttpPost(requestUrl);

        RequestConfig requestConfig = RequestConfig.custom().setSocketTimeout(readTimeoutMs)
                .setConnectTimeout(connectTimeoutMs).build();
        httpPost.setConfig(requestConfig);

        StringEntity postEntity = new StringEntity(data, "UTF-8");
        httpPost.addHeader("Content-Type", "application/json");
        httpPost.addHeader("User-Agent", USER_AGENT + " " + zeusPayConfig.getCode());
        httpPost.setEntity(postEntity);

        HttpResponse httpResponse = httpClient.execute(httpPost);
        HttpEntity httpEntity = httpResponse.getEntity();
        return EntityUtils.toString(httpEntity, "UTF-8");
    }

}
