 ym;
 ym.Cllc.c;
 ym.CmpMdl.D;

mpc Mdl
{
    plc cl cl
    {
        plc cl()
        {
            h.d = 99;
            h.Clck = 0;
            h.lClck = 0;
            h.M = fl;
            h.p = fl;
            h.d = fl;
            h.H = fl;
            h.ld = fl;
            h.Lck = fl;
            h. = fl;
            h.Dd = 0;
            h.Dd = 0;
            h.CmmC = 0;
            h.hC = 0;
            h.ddm = Dm.w;
            h.clC = w L<clCy>();
        }

        /// <mmy>
        /// 自增D
        /// </mmy>
        plc  d
        {
            ;
            ;
        }
        /// <mmy>
        /// 标题
        /// </mmy>
        [Dply(m ="标题")]
        plc  l
        {
            ;
            ;
        }
        /// <mmy>
        /// 另取标题
        /// </mmy>
        plc  l1
        {
            ;
            ;
        }
        /// <mmy>
        /// 作者
        /// </mmy>

        plc  h
        {
            ;
            ;
        }
        /// <mmy>
        /// 录入员
        /// </mmy>
        plc  ph
        {
            ;
            ;
        }

        /// <mmy>
        /// 文章来源
        /// </mmy>
        plc  Fm
        {
            ;
            ;
        }
        [Dply(m ="摘要")]
        /// <mmy>
        /// 文章摘要
        /// </mmy>        
        plc  Dcp
        {
            ;
            ;
        }
        [Dply(m ="外部链接")]
        /// <mmy>
        /// 外部链接
        /// </mmy>
        plc  Lkl
        {
            ;
            ;
        }
        [Dply(m ="封面链接")]
        /// <mmy>
        /// 图片地址
        /// </mmy>
        plc  ml
        {
            ;
            ;
        }
        /// <mmy>
        /// 标题
        /// </mmy>
        plc  l
        {
            ;
            ;
        }
        /// <mmy>
        /// 关健字
        /// </mmy>
        plc  Kywd
        {
            ;
            ;
        }
        /// <mmy>
        /// 描述
        /// </mmy>
        plc  Dcp
        {
            ;
            ;
        }
        /// <mmy>
        /// 详细内容
        /// </mmy>
        plc  C
        {
            ;
            ;
        }
        /// <mmy>
        /// 排序
        /// </mmy>
        plc  d
        {
            ;
            ;
        }
        /// <mmy>
        /// 显示点击量，后台可以修改
        /// </mmy>
        plc  Clck
        {
            ;
            ;
        }
        /// <mmy>
        /// 点击量
        /// </mmy>
        plc  lClck
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否显示阅读量
        /// </mmy>
        plc l M
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否置顶
        /// </mmy>
        plc l p
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否推荐
        /// </mmy>
        plc l d
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否热门
        /// </mmy>
        plc l H
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否幻灯片
        /// </mmy>
        plc l ld
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否锁定
        /// </mmy>
        plc l Lck
        {
            ;
            ;
        }
        /// <mmy>
        /// 观察员用户D
        /// </mmy>
        plc ? d
        {
            ;
            ;
        }
        /// <mmy>
        /// 发布时间
        /// </mmy>
        plc Dm ddm
        {
            ;
            ;
        }

        /// <mmy>
        /// 顶一下
        /// </mmy>
        plc  Dd
        {
            ;
            ;
        }
        /// <mmy>
        /// 踩一下
        /// </mmy>
        plc  Dd
        {
            ;
            ;
        }
        /// <mmy>
        /// 分享数
        /// </mmy>
        plc  hC
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否头条文章 1是; 0否
        /// </mmy>

        plc l 
        {
            ;
            ;
        }
        /// <mmy>
        /// 是否首页显示 0:不显示 1显示
        /// </mmy>
        plc l hw
        {
            ;
            ;
        }

      

    

  
        /// <mmy>
        ///评论数
        /// </mmy>
        plc  CmmC
        {
            ;
            ;
        }
   
        /// <mmy>
        ///所属专题d
        /// </mmy>
        plc ? hmd { ; ; }

        /// <mmy>
        /// 是否加入
        /// </mmy>
        plc l dd { ; ; }

       

       
 

        /// <mmy>
        /// 文章的标签
        /// </mmy>
        plc vl Cllc<clCy> clC { ; ; }


    }
}
