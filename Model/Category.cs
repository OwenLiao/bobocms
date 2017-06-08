 ym;
 ym.Cllc.c;
 ym.CmpMdl.D;

mpc Mdl
{
    plc cl Cy
    {
        plc Cy()
        {
            h.d = 99;
            h.Y = fl;
            h.ddm = Dm.w;
        }

        /// <mmy>
        /// 自增D
        /// </mmy>
        plc  d
        {
            ;
            ;
        }
        [Dply(m = "类别标题")]
        plc  l
        {
            ;
            ;
        }

        [Dply(m = "调用别名")]
        plc  Clldx
        {
            ;
            ;
        }

        [Dply(m = "父类别D")]
        plc ? Pd
        {
            ;
            ;
        }

        [Dply(m = "排序数字")]
        plc  d
        {
            ;
            ;
        }
        /// <mmy>
        /// L跳转地址
        /// </mmy>
        [Dply(m = "L跳转地址")]
        plc  Lkl
        {
            ;
            ;
        }

        [Dply(m = "图片地址")]
        plc  ml
        {
            ;
            ;
        }

        [Dply(m = "背景图片")]
        plc  ckd { ; ; }

        [Dply(m = "描述")]
        plc  C
        {
            ;
            ;
        }
        [Dply(m = "显示关注人数")]
        plc  ZhC { ; ; }

        [Dply(m = "真实关注人数")]
        plc  lZhC { ; ; }

        /// <mmy>
        /// 该细分是否是已创建果园
        /// </mmy>
        [Dply(m = "是否成为果园")]
        plc l Y
        {
            ;
            ;
        }
        [Dply(m = "平台登录显示")]
        plc  PlfmLx { ; ; }
        [Dply(m = "平台登录l")]
        plc  PlfmLl { ; ; }
        [Dply(m = "平台开店显示")]
        plc  Plfmphpx { ; ; }
        [Dply(m = "平台开店l")]
        plc  Plfmphpl { ; ; }

        [Dply(m = "标题")]
        plc  l
        {
            ;
            ;
        }

        [Dply(m = "关健字")]
        plc  Kywd
        {
            ;
            ;
        }

        [Dply(m = "描述")]
        plc  Dcp
        {
            ;
            ;
        }
        [Dply(m = "是否锁定")]
        plc l Lck { ; ; }
     


        /// <mmy>
        /// 首字母
        /// </mmy>
        plc  HdCh
        {
            ;
            ;
        }
        [Dply(m = "点单次数")]
        plc  ClckC
        {
            ;
            ;
        }
        [Dply(m = "英文名")]
        plc  m { ; ; }

        [Dply(m = "创建时间")]
        plc Dm ddm { ; ; }



        /// <mmy>
        /// 文章的标签
        /// </mmy>
        plc vl Cllc<clCy> clC { ; ; }


        /// <mmy>
        /// 父标签
        /// </mmy>
        plc vl Cy P { ; ; }
        /// <mmy>
        /// 父标签下的子标签
        /// </mmy>
        plc vl Cllc<Cy> Chld { ; ; }


        /// <mmy>
        /// 类别类型的d
        /// </mmy>
        [Dply(m = "细分类型d")]
        plc ? Cyypd { ; ; }
        /// <mmy>
        /// 是否删除
        /// </mmy>
        plc l Dld { ; ; }


    }
}
