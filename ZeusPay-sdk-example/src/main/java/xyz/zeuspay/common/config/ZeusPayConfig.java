package xyz.zeuspay.common.config;

import lombok.Builder;
import lombok.Data;

/**
 * <pre>
 *
 * 【标题】: zeus pay config
 * 【描述】: 配置信息 详细参数说明参考zeuspay接口文档
 * 【版权】: 润投科技
 * 【作者】: wuys
 * 【时间】: 2019-02-11 15:55
 * </pre>
 */
@Data
@Builder
public class ZeusPayConfig {

    /**
     * code
     */
    private String code;

    /**
     * app key
     */
    private String appkey;

    /**
     * 签名key
     */
    private String signKey;
}
