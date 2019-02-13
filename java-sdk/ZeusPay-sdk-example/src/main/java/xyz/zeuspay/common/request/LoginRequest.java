package xyz.zeuspay.common.request;

import lombok.Data;
import xyz.zeuspay.common.config.ZeusPayConfig;

/**
 * <pre>
 *
 * 【标题】: 登录zeus平台的request
 * 【描述】:
 * 【版权】: 润投科技
 * 【作者】: wuys
 * 【时间】: 2019-02-11 16:38
 * </pre>
 */
@Data
public class LoginRequest extends DefaultPayRequest{

    public LoginRequest(ZeusPayConfig zeusPayConfig) {
        super(zeusPayConfig);
    }


}
