package xyz.zeuspay;

import com.google.common.collect.Maps;
import org.junit.Test;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import xyz.zeuspay.common.config.ZeusPayConfig;
import xyz.zeuspay.common.request.DefaultPayRequest;
import xyz.zeuspay.common.request.LoginRequest;

import java.util.HashMap;

/**
 * Unit test for simple App.
 */
public class PayTest {

    private static final Logger log = LoggerFactory.getLogger(PayTest.class);

    /**
     * 登录测试样例
     */
    @Test
    public void zeusPayLoginTest() {
        String url = "http://192.168.1.5/api/public/authconnect";
        Long userId = 12345679L;
        String appKey = "90391DB54237128D56B660A4D0CDFE4E";
        String code = "ZM";
        String signKey = "65d2e224ed894f92b206b2f5fe189334";
        // String nonStr = RandomUtil.randomStringFixLength(5);
        HashMap<String, String> paramMap = Maps.newHashMapWithExpectedSize(5);
        paramMap.put("identifier", userId + "");
        paramMap.put("appkey", appKey);
        paramMap.put("code", code);
        // paramMap.put("nonStr", nonStr);
        try {
            ZeusPayConfig zeusPayConfig = ZeusPayConfig.builder().appkey(appKey).code(code).signKey(signKey).build();
            String result = new LoginRequest(zeusPayConfig).postExecute(url, paramMap, 10, 10);
            System.out.println(result);
            log.debug(result);
        } catch (Exception e) {
            log.error("aobc登录出错!", e);
        }
    }

    @Test
    public void zeusPayTest(){
        String url = "http://192.168.1.5/api/public/payrequest";
        Long identifier = 173960116574380032L;
        String appkey = "90391DB54237128D56B660A4D0CDFE4E";
        String code = "ZM";
        String token = "123421312";
        String signKey = "65d2e224ed894f92b206b2f5fe189334";
        //String nonStr = RandomUtil.randomStringFixLength(5);
        HashMap<String, String> paramMap = Maps.newHashMapWithExpectedSize(5);
        //int amt = 1;
        //商户号
        Long zmId = 21375971L;
        //Long payer = 21375972L;
        String callback = "http://192.168.1.208:9090/InfoOpSys/aobcpay/callback";
        String cur = "BTC";
        //订单id
        long orderNextId = 987654321L;
        paramMap.put("identifier", identifier + "");
        paramMap.put("appkey", appkey);
        paramMap.put("token",token);
        paramMap.put("code", code);
        paramMap.put("amt","1");
        paramMap.put("payee",zmId + "");
        //paramMap.put("payer",payer + "");
        paramMap.put("cur",cur);
        paramMap.put("callback",callback);
        paramMap.put("transaction",orderNextId + "");

        try {
            ZeusPayConfig zeusPayConfig = ZeusPayConfig.builder().signKey(signKey).code(code).appkey(appkey).build();
            String result = new DefaultPayRequest(zeusPayConfig).postExecute(url, paramMap, 10, 10);
            log.debug(result);
        } catch (Exception e) {
            log.error("zeuspay支付接口调用失败!",e);
        }
    }


}
